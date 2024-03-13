using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using application.Specifications.crm;
using domain.Dto.crm;
using domain.Entities.crm;
using domain.Interfaces.Repositories;
using domain.Interfaces.ICRUDservices.crm;

namespace xtend_platform_application.CRUDservices.crm
{
    public class CompanyTypeServices : ICompanyTypeServices
    {

        private readonly IRepository<CompanyType> _repository;
        private readonly IMapper _mapper;

        public CompanyTypeServices(IRepository<CompanyType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CompanyTypeDto> AddEntity(CompanyTypeDto dto)
        {
            var entity = _mapper.Map<CompanyType>(dto);
            await _repository.Add(entity);
            return _mapper.Map<CompanyTypeDto>(entity);
        }

        public async Task<CompanyTypeDto> DeleteEntity(int id)
        {
            var entity = await _repository.GetSingleBySpec(new CompanyTypeGetByIdSpecification(id));
            if (entity != null)
            {
                entity.IsDeleted = true;
                await _repository.Update(entity);
            }

            return _mapper.Map<CompanyTypeDto>(entity);
        }

        public async Task<List<CompanyTypeDto>> GetEntities()
        {
            return _mapper.Map<List<CompanyTypeDto>>(await _repository.List(new NotDeletedCompanyTypeSpec()));
        }

        public async Task<CompanyTypeDto> GetEntity(int id)
        {
            var companyStatus = await _repository.GetSingleBySpec(new CompanyTypeSpecification(id));
            return _mapper.Map<CompanyTypeDto>(companyStatus);
        }

        public async Task<CompanyTypeDto> UpdateEntity(int id, CompanyTypeDto dto)
        {
            var entity = await _repository.GetById(id);
            _mapper.Map(dto, entity);
            await _repository.Update(entity);
            return _mapper.Map<CompanyTypeDto>(entity);
        }
    }
}
