using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using application.Specifications.cpm;
using domain.Dto.realestate;
using domain.Entities.releastate;
using domain.Interfaces.Repositories;
using domain.Interfaces.ICRUDservices.cpm;
using domain.Entities.users;

namespace application.CRUDservices.cpm
{
    public class RealestateCatalogTypeServices : IRealestateCatalogTypeServices
    {
        private readonly IRepository<CatalogType> _catalogTypeRepository;
        private readonly IMapper _mapper;

        public RealestateCatalogTypeServices(IRepository<CatalogType> catalogTypeRepository, IMapper mapper)
        {
            _catalogTypeRepository = catalogTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<CatalogTypeDto>> GetEntities()
        {
            
            return _mapper.Map<List<CatalogTypeDto>>(await _catalogTypeRepository.List(new NotDeletedCatalogTypeSpec()));
        }
        public async Task<CatalogTypeDto> GetEntity(int id)
        {
            var appContactRole = await _catalogTypeRepository.GetSingleBySpec(new CatalogTypeGetByIdAndIncludeAllSpecification(id));

            return _mapper.Map<CatalogTypeDto>(appContactRole);
        }
        public Task<CatalogTypeDto> AddEntity(CatalogTypeDto dto)
        {
            throw new NotImplementedException();
        }
        public Task<CatalogTypeDto> DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }
        public Task<CatalogTypeDto> UpdateEntity(int id, CatalogTypeDto dto)
        {
            throw new NotImplementedException();
        }
    }
}