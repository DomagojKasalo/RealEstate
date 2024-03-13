using AutoMapper;
using application.Specifications.cpm;
using domain.Dto.realestate;
using domain.Entities.releastate;
using domain.Interfaces.Repositories;
using domain.Interfaces.ICRUDservices.cpm;

namespace application.CRUDservices.cpm
{
    public class RealestateCatalogItemStatusServices : IRealestateCatalogItemStatusServices
    {
        private readonly IRepository<CatalogItemStatus> _realestateCatalogItemStatusRepository;
        private readonly IMapper _mapper;

        public RealestateCatalogItemStatusServices(IRepository<CatalogItemStatus> realestateCatalogItemStatusRepository, IMapper mapper)
        {
            _realestateCatalogItemStatusRepository = realestateCatalogItemStatusRepository;
            _mapper = mapper;
        }
        public async Task<List<CatalogItemStatusDto>> GetEntities()
        {
            return _mapper.Map<List<CatalogItemStatusDto>>(await _realestateCatalogItemStatusRepository.List(new NotDeletedCatalogItemStatusSpec()));
        }
        public async Task<CatalogItemStatusDto> GetEntity(int id)
        {
            var appContactRole = await _realestateCatalogItemStatusRepository.GetSingleBySpec(new CatalogItemStatusGetByIdAndIncludeAllSpecification(id));

            return _mapper.Map<CatalogItemStatusDto>(appContactRole);
        }
        public Task<CatalogItemStatusDto> AddEntity(CatalogItemStatusDto dto)
        {
            throw new NotImplementedException();
        }
        public Task<CatalogItemStatusDto> DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }
        public Task<CatalogItemStatusDto> UpdateEntity(int id, CatalogItemStatusDto dto)
        {
            throw new NotImplementedException();
        }
    }
}