using System.Collections.Generic;
using System.Threading.Tasks;
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
    public class RealestateCatalogTypesController : ControllerBase
    {
        private readonly IRealestateCatalogTypeServices _realestateCatalogTypeServices;

        public RealestateCatalogTypesController(IRealestateCatalogTypeServices realestateCatalogTypeServices)
        {
            _realestateCatalogTypeServices = realestateCatalogTypeServices;
        }

        // GET: api/cpm/v1/RealestateCatalogTypes
        [HttpGet]
        public async Task<List<CatalogTypeDto>> GetRealestateCatalogTypes()
        {
            
            return await _realestateCatalogTypeServices.GetEntities();
        }

        // GET: api/cpm/v1/RealestateCatalogType/5
        [HttpGet("{id}")]
        public async Task<CatalogTypeDto> GetRealestateCatalogType([FromRoute] int id)
        {
            var dto = await _realestateCatalogTypeServices.GetEntity(id);

            return dto;
        }
    }
}
