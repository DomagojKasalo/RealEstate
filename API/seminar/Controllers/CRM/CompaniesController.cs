using Microsoft.AspNetCore.Mvc;
using domain.Dto.crm;
using domain.Interfaces.ICRUDservices.crm;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers.CRM.V1
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyServices _companyServices;

        public CompaniesController(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        // GET: api/crm/v1/Companies
        [HttpGet]
        public async Task<List<CompanyDto>> GetCompanies()
        {
            return await _companyServices.GetEntities();
        }

        // GET: api/crm/v1/Companies/light
        [HttpGet("light")]
        public async Task<List<CompanyLightDto>> GetCompaniesLight()
        {
            return await _companyServices.GetLightEntities();
        }

        // GET: api/crm/v1/Companies/5
        [HttpGet("{id}")]
        public async Task<CompanyDto> GetCompany([FromRoute] int id)
        {
            return await _companyServices.GetEntity(id);
        }

        // PUT: api/crm/v1/Companies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany([FromRoute] int id, [FromForm] CompanyDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dto.Id)
            {
                return BadRequest();
            }

            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                // Generate a unique file name based on a new Guid
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.ImageFile.FileName);

                // Combine the directory path with the unique file name
                var filePath = Path.Combine("wwwroot/images", fileName);

                // Save the file to the filePath
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(fileStream);
                }

                // Update the ImagePath in the DTO
                dto.ImagePath = "/images/" + fileName;
            }

            // Perform update operation
            var result = await _companyServices.UpdateEntity(id, dto);
            return Ok(result);
        }

        // PUT: api/crm/v1/CompaniesForCPM/5
        [HttpPut("{id}/cpm")]
        public async Task<IActionResult> PutCompanyForCPM([FromRoute] int id, CompanyCPMDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dto.Id)
            {
                return BadRequest();
            }

            return Ok(await _companyServices.UpdateEntity(id, dto));
        }

        // POST: api/crm/v1/Companies
        [HttpPost]
        public async Task<IActionResult> PostCompany([FromForm] CompanyDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                // Generate a unique file name based on a new Guid
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.ImageFile.FileName);

                // Combine the directory path with the unique file name
                var filePath = Path.Combine("wwwroot/images", fileName);

                // Save the file to the filePath
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(fileStream);
                }

                // Update the ImagePath in the DTO
                dto.ImagePath = "/images/" + fileName;
            }

            // Perform the creation operation
            var result = await _companyServices.AddEntity(dto);
            return Ok(result);
        }

        // DELETE: api/crm/v1/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] int id)
        {
            return Ok(await _companyServices.DeleteEntity(id));
        }
    }
}
