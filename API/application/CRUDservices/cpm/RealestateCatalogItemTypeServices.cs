using AutoMapper;
using application.Specifications.cpm;
using domain.Dto.realestate;
using domain.Entities.releastate;
using domain.Interfaces.Repositories;
using domain.Interfaces.ICRUDservices.cpm;

namespace application.CRUDservices.cpm
{
    public class RealestateCatalogItemTypeServices : IRealestateCatalogItemTypeServices
    {
        private readonly IRepository<CatalogItemType> _realestateCatalogItemTypeRepository;
        private readonly IMapper _mapper;

        public RealestateCatalogItemTypeServices(IRepository<CatalogItemType> realestateCatalogItemTypeRepository, IMapper mapper)
        {
            _realestateCatalogItemTypeRepository = realestateCatalogItemTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<CatalogItemTypeDto>> GetEntities()
        {
            return _mapper.Map<List<CatalogItemTypeDto>>(await _realestateCatalogItemTypeRepository.List(new NotDeletedCatalogItemTypeSpec()));
        }
        public async Task<CatalogItemTypeDto> GetEntity(int id)
        {
            var appContactRole = await _realestateCatalogItemTypeRepository.GetSingleBySpec(new CatalogItemTypeGetByIdAndIncludeAllSpecification(id));

            return _mapper.Map<CatalogItemTypeDto>(appContactRole);
        }
        public Task<CatalogItemTypeDto> AddEntity(CatalogItemTypeDto dto)
        {
            throw new NotImplementedException();
        }
        public Task<CatalogItemTypeDto> DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }
        public Task<CatalogItemTypeDto> UpdateEntity(int id, CatalogItemTypeDto dto)
        {
            throw new NotImplementedException();
        }
    }
}