using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using domain.Dto.crm;
using domain.Interfaces.ICRUDservices.crm;

namespace api.Controllers.CRM.V1
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CompanyTypesController : ControllerBase
    {
        private readonly ICompanyTypeServices _companyTypeServices;

        public CompanyTypesController(ICompanyTypeServices companyTypeServices)
        {
            _companyTypeServices = companyTypeServices;
        }

        //[Authorize(Roles = "Admin, Basic User")]
        // GET: api/crm/v1/CompanyTypes
        [HttpGet]
        public async Task<List<CompanyTypeDto>> GetCompanyTypes()
        {
            return await _companyTypeServices.GetEntities();
        }

        [Authorize(Roles = "Admin, Basic User")]
        // GET: api/crm/v1/CompanyTypes/5
        [HttpGet("{id}")]
        public async Task<CompanyTypeDto> GetCompanyType([FromRoute] int id)
        {
            return await _companyTypeServices.GetEntity(id);
        }

        // PUT: api/crm/v1/CompanyTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyType([FromRoute] int id, CompanyTypeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dto.Id)
            {
                return BadRequest();
            }

            return Ok(await _companyTypeServices.UpdateEntity(id, dto));
        }

        // POST: api/crm/v1/CompanyTypes
        [HttpPost]
        public async Task<IActionResult> PostCompanyType([FromBody] CompanyTypeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _companyTypeServices.AddEntity(dto));
        }

        // DELETE: api/crm/v1/CompanyTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyType([FromRoute] int id)
        {
            return Ok(await _companyTypeServices.DeleteEntity(id));
        }

    }
}
