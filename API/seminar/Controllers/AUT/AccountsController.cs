using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using domain.Entities.users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using domain.Models;
using domain.Interfaces.ICRUDservices.cpm;
using domain.Entities.email;
using persistance.Datacontext;
using domain.Interfaces.ICRUDservices.crm;
using application.CRUDservices.cpm;
using domain.Dto.relestate;
using domain.Dto.users;
using domain.Dto.crm;
using domain.Entities.crm;
using persistance.Mapper.CRM;
using Humanizer;
using AutoMapper;

namespace api.Controllers.AUT.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountsController> _logger;
        private readonly IEmailServices _emailService;
        private readonly AppDbContext _context;
        private readonly IRealestateCatalogItemServices _catalogItemService;
        private readonly ICompanyServices _companyService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountsController(
            UserManager<User> userManager,
            AppDbContext context, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            ILogger<AccountsController> logger,
            IEmailServices emailService,
            IRealestateCatalogItemServices catalogItemService,
            ICompanyServices companyService,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _logger = logger;
            _emailService = emailService;
            _context = context;
            _catalogItemService = catalogItemService;
            _companyService = companyService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("sendmail")]
        public async Task<IActionResult> SendMail([FromBody] SendMailRequest request)
        {
            await CreateInvitation(request);

            return Ok();
        }

        private async Task CreateInvitation(SendMailRequest request)
        {
            var companyIdClaim = _httpContextAccessor.HttpContext.User.FindFirst("CompanyIdClaimType");
            int? companyId = null;

            if (companyIdClaim != null && int.TryParse(companyIdClaim.Value, out var parsedCompanyId))
            {
                companyId = parsedCompanyId;
            }

            if (!companyId.HasValue)
            {
                throw new InvalidOperationException("The current user is not associated with any company.");
            }

            var invitation = new Invitation
            {
                Code = Guid.NewGuid().ToString(),
                Email = request.Email,
                CompanyId = companyId.Value 
            };

            await _context.Invitations.AddAsync(invitation);
            await _context.SaveChangesAsync();

            var emailMessage = new SendMailRequest
            {
                Email = request.Email,
                Subject = request.Subject,
                Message = $"{request.Message}\n\nYour invitation code is: {invitation.Code}"
            };

            await _emailService.SendMail(emailMessage);
        }



        [HttpPost("reserveOrBuy")]
        public async Task<IActionResult> ReserveOrBuyItem([FromBody] ReserveOrBuyItemRequest request)
        {
            var dto = await _catalogItemService.GetEntity(request.ItemId);
            var company = await _companyService.GetEntity(dto.CompanyId);

            var sendMailRequest = new SendReservationOrPurchaseEmailRequest
            {
                User = request.User,
                CatalogItem = dto,
                Email = company.Email,
                Action = request.Action
            };

            await _emailService.SendMail2(sendMailRequest);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("registerUser")]
        public async Task<IActionResult> Register([FromBody] RegisterBasicUser request)
        {
            var invitation = _context.Invitations.FirstOrDefault(i => i.Code == request.InviteCode);
            if (invitation == null)
            {
                return BadRequest("Invalid invite code.");
            }

            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                CompanyId = invitation.CompanyId 
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            result = await _userManager.AddToRoleAsync(user, "Basic User");
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { UserId = user.Id });
        }



        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var newUser = new User { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "Admin");
                return Ok();
            }

            return BadRequest(result.Errors);
        }


        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserModel model)
        {
            var newUser = new User
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                CompanyId = model.CompanyId
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                foreach (var role in model.Roles)
                {
                    if (await _roleManager.RoleExistsAsync(role))
                    {
                        await _userManager.AddToRoleAsync(newUser, role);
                    }
                    else
                    {
                        return BadRequest("Role does not exist");
                    }
                }

                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("test-auth")]
        public IActionResult TestAuthentication()
        {
            var isAuthenticated = User.Identity.IsAuthenticated;
            return Ok($"You are {(isAuthenticated ? "" : "not ")}authenticated.");
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var email = model.Email.ToUpper();
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                _logger.LogInformation($"User roles: {string.Join(", ", userRoles)}");

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("CompanyIdClaimType", user.CompanyId.ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }


                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddHours(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }


        // Get User
        [HttpGet("User/{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            _logger.LogInformation($"Searching for user with ID: {id}");

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                _logger.LogWarning($"No user found with ID: {id}");
                return NotFound();
            }

            _logger.LogInformation($"Found user with ID: {id}");
            return Ok(user);
        }

        [HttpGet("User/{id}/role")]
        //[Authorize] 
        public async Task<ActionResult<object>> GetUserRole(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Count == 0)
            {
                return BadRequest("User has no roles.");
            }

            var userRole = roles[0];

            return Ok(new { Role = userRole }); // Return a JSON object with the role property
        }



        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        [HttpDelete("User/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userManager.DeleteAsync(user);
            return NoContent();
        }

        // Get all users
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("User")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _context.Users.Include(u => u.Company).ToListAsync();

            var userDtos = _mapper.Map<List<UserDto>>(users);

            foreach (var userDto in userDtos)
            {
                var userEntity = users.First(u => u.Id.ToString() == userDto.Id);
                userDto.Roles = await _userManager.GetRolesAsync(userEntity);
            }

            return Ok(userDtos);
        }

        [HttpGet("Roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = _roleManager.Roles;

            if (roles == null)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        [HttpPut("User/{id}")]
        public async Task<IActionResult> UpdateUser(string id, UserDto model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _mapper.Map(model, user);

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                if (model.Roles != null && !model.Roles.Contains(role))
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                }
            }

            if (model.Roles != null)
            {
                foreach (var role in model.Roles)
                {
                    if (!await _roleManager.RoleExistsAsync(role))
                    {
                        return BadRequest("Role does not exist");
                    }

                    if (!userRoles.Contains(role))
                    {
                        await _userManager.AddToRoleAsync(user, role);
                    }
                }
            }

            return Ok();
        }

        //private string GenerateJWTToken(User userInfo)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
        //      _configuration["Jwt:Issuer"],
        //      null,
        //      expires: DateTime.Now.AddMinutes(120),
        //      signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}
