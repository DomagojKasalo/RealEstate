using AutoMapper;
using System.Net;
using System.Web.Http;
using application.Specifications.cpm;
using domain.Dto.relestate;
using domain.Entities.releastate;
using domain.Interfaces.Repositories;
using domain.Interfaces.ICRUDservices.cpm;
using Microsoft.AspNetCore.Http;
using application.Specifications;
using application.Specifications.crm;

namespace application.CRUDservices.cpm
{
    public class RealestateCatalogServices : IRealestateCatalogServices
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Catalog> _realEstateCatalogRepository;
        private readonly IRepository<CatalogItem> _realEstateCatalogItemRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RealestateCatalogServices(
            IMapper mapper, 
            IRepository<Catalog> realEstateCatalogRepository, 
            IRepository<CatalogItem> realEstateCatalogItemRepository,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _mapper = mapper;
            _realEstateCatalogRepository = realEstateCatalogRepository;
            _realEstateCatalogItemRepository = realEstateCatalogItemRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<RealEstateCatalogDto>> GetEntities()
        {
            var userCompanyId = GetCurrentUserCompanyIdNullable();

            BaseSpecification<Catalog> spec;
            if (userCompanyId.HasValue)
            {
                spec = new NotDeletedRealEstateCatalogSpec(userCompanyId.Value);
            }
            else
            {
                spec = new AllRealEstateCatalogSpec();
            }

            return _mapper.Map<List<RealEstateCatalogDto>>(await _realEstateCatalogRepository.List(spec));
        }

        private int? GetCurrentUserCompanyIdNullable()
        {
            var companyIdClaim = _httpContextAccessor.HttpContext.User.FindFirst("CompanyIdClaimType");
            if (companyIdClaim != null && int.TryParse(companyIdClaim.Value, out var companyId))
            {
                return companyId;
            }
            return null; 
        }
        public async Task<List<RealEstateCatalogDto>> GetAllEntities()
        {
            return _mapper.Map<List<RealEstateCatalogDto>>(await _realEstateCatalogRepository.List(new NotDeleatedCatalogSpec()));
        }
        public async Task<RealEstateCatalogDto> GetEntity(int id)
        {
            var brand = await _realEstateCatalogRepository.GetSingleBySpec(new RealEstateCatalogGetByIdAndIncludeAllSpecification(id));

            return _mapper.Map<RealEstateCatalogDto>(brand);
        }
        public async Task<List<RealEstateCatalogItemDto>> GetCatalogCatalogItems(int id)
        {
            var catalogItem = await _realEstateCatalogItemRepository.List(new CatalogItemSpecification(id));
            return _mapper.Map<List<RealEstateCatalogItemDto>>(catalogItem);
        }
        public async Task<RealEstateCatalogDto> UpdateEntity(int id, RealEstateCatalogDto dto)
        {
            var entity = await _realEstateCatalogRepository.GetById(id);
            _mapper.Map(dto, entity);
            await _realEstateCatalogRepository.Update(entity);

            return _mapper.Map<RealEstateCatalogDto>(entity);
        }
        public async Task<RealEstateCatalogDto> AddEntity(RealEstateCatalogDto dto)
        {
            var entity = _mapper.Map<Catalog>(dto);
            entity.IsEnabled = true;

            await _realEstateCatalogRepository.Add(entity);

            return _mapper.Map<RealEstateCatalogDto>(entity);
        }
        public async Task<RealEstateCatalogDto> DeleteEntity(int id)
        {
            var entity = await _realEstateCatalogRepository.GetSingleBySpec(new RealEstateCatalogGetByIdSpecification(id));

            var catalogItem = await GetCatalogCatalogItems(id);
            if (catalogItem.Count == 0)
            {
                if (entity != null)
                {
                    entity.IsDeleted = true;
                    await _realEstateCatalogRepository.Update(entity);
                }

                return _mapper.Map<RealEstateCatalogDto>(entity);

            }
            else
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Unable to delete catalog {0} because it contains catalgIteme!", id)),
                    ReasonPhrase = "Catalog Not Found"
                };
                throw new HttpResponseException(resp);
            }
        }
        public async Task<RealEstateCatalogDto> UpdateIsEnabledCatalog(int catalogId, bool isEnabledValue)
        {
            var catalog = await _realEstateCatalogRepository.GetSingleBySpec(new RealEstateCatalogGetByIdSpecification(catalogId));
            if (catalog != null)
            {
                catalog.IsEnabled = isEnabledValue;
                await _realEstateCatalogRepository.Update(catalog);
            }
            return _mapper.Map<RealEstateCatalogDto>(catalog);
        }
    }        
}
