using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using domain.Dto.realestate;
using domain.Interfaces.ICRUDservices.cpm;

namespace api.Controllers.CPM.V1
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RealestateCatalogItemStatusController : ControllerBase
    {
        private readonly IRealestateCatalogItemStatusServices _realestateCatalogItemStatusServices;

        public RealestateCatalogItemStatusController(IRealestateCatalogItemStatusServices realestateCatalogItemStatusServices)
        {
            _realestateCatalogItemStatusServices = realestateCatalogItemStatusServices;
        }

        // GET: api/cpm/v1/CatalogItemStatuses
        [HttpGet]
        public async Task<List<CatalogItemStatusDto>> GetCatalogItemStatuses()
        {
            return await _realestateCatalogItemStatusServices.GetEntities();
        }

        // GET: api/cpm/v1/CatalogItemStatus/5
        [HttpGet("{id}")]
        public async Task<CatalogItemStatusDto> GetCatalogItemStatus([FromRoute] int id)
        {
            var dto = await _realestateCatalogItemStatusServices.GetEntity(id);

            return dto;
        }
    }
}
