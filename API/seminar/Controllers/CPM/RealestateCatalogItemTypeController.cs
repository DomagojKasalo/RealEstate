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
    public class RealestateCatalogItemTypeController : ControllerBase
    {
        private readonly IRealestateCatalogItemTypeServices _realestateCatalogItemTypeServices;

        public RealestateCatalogItemTypeController(IRealestateCatalogItemTypeServices realestateCatalogItemTypeServices)
        {
            _realestateCatalogItemTypeServices = realestateCatalogItemTypeServices;
        }

        // GET: api/cpm/v1/CatalogItemTypes
        [HttpGet]
        public async Task<List<CatalogItemTypeDto>> GetCatalogItemTypes()
        {
            return await _realestateCatalogItemTypeServices.GetEntities();
        }

        // GET: api/cpm/v1/AppContactRoles/5
        [HttpGet("{id}")]
        public async Task<CatalogItemTypeDto> GetCatalogItemTypes([FromRoute] int id)
        {
            var dto = await _realestateCatalogItemTypeServices.GetEntity(id);

            return dto;
        }
    }
}
