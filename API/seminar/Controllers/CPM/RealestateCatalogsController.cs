using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using api.Options;
using domain.Dto.relestate;
using domain.Interfaces.ICRUDservices.cpm;
using persistance.Datacontext;

namespace api.Controllers.CPM.V1
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RealestateCatalogsController : ControllerBase
    {
        private readonly IRealestateCatalogServices _realestateCatalogServices;
        private readonly UrlsOptions _urlsOptions;
        private readonly AppDbContext _context;

        public RealestateCatalogsController(AppDbContext context, IRealestateCatalogServices realestateCatalogServices, IOptions<UrlsOptions> optionsAccessor)
        {
            _realestateCatalogServices = realestateCatalogServices;
            _urlsOptions = optionsAccessor.Value;
            _context = context;
        }

        // GET: api/cpm/v1/Catalogs
        [HttpGet("all")]
        public async Task<List<RealEstateCatalogDto>> GetAllRealestateCatalogs()
        {
            var dto = await _realestateCatalogServices.GetAllEntities();

            return dto;
        }

        // GET: api/cpm/v1/Catalogs
        [HttpGet]
        public async Task<List<RealEstateCatalogDto>> GetRealestateCatalogs()
        {
            var dto = await _realestateCatalogServices.GetEntities();

            return dto;
        }

        // GET: api/cpm/v1/Catalogs/5
        [HttpGet("{id}")]
        public async Task<RealEstateCatalogDto> GetCatalog([FromRoute] int id)
        {
            var dto = await _realestateCatalogServices.GetEntity(id);

            return dto;
        }

        // GET: api/cpm/v1/Catalogs/5/CatalogItems
        [HttpGet("{catalogId}/catalogItems")]
        public async Task<List<RealEstateCatalogItemDto>> GetCatalogCatalogItems([FromRoute] int catalogId)
        {
            var dto = await _realestateCatalogServices.GetCatalogCatalogItems(catalogId);

            return dto;
        }

        // PUT: api/cpm/v1/Catalogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalog([FromRoute] int id, RealEstateCatalogDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dto.Id)
            {
                return BadRequest();
            }

            var result = await _realestateCatalogServices.UpdateEntity(id, dto);

            return Ok(result);
        }

        // PUT: api/cpm/v1/Catalogs/5/updateIsEnabled
        [HttpPut("{catalogId}/updateIsEnabled/{isEnabledValue}")]
        public async Task<IActionResult> UpdateIsEnabledCatalog([FromRoute] int catalogId, bool isEnabledValue)
        {
            var dto = await _realestateCatalogServices.UpdateIsEnabledCatalog(catalogId, isEnabledValue);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.SaveChangesAsync();

            return Ok(dto);
        }

        // POST: api/cpm/v1/Catalogs
        [HttpPost]
        public async Task<IActionResult> PostCatalog([FromBody] RealEstateCatalogDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _realestateCatalogServices.AddEntity(dto);

            return Ok(result);
        }

        // DELETE: api/cpm/v1/Catalogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalog([FromRoute] int id)
        {
            var result = await _realestateCatalogServices.DeleteEntity(id);

            return Ok(result);
        }
    }
}