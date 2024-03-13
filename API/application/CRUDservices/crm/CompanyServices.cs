using System.Collections.Generic;
using System.Threading.Tasks;
using domain.Dto.crm;
using domain.Entities.crm;
using AutoMapper;
using domain.Interfaces.Repositories;
using domain.Interfaces.ICRUDservices.crm;
using application.Specifications.crm;

namespace application.CRUDservices.crm
{
    public class CompanyServices : ICompanyServices
    {
        private readonly IRepository<Company> _repository;

        private readonly IMapper _mapper;


        public CompanyServices(IRepository<Company> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CompanyDto>> GetEntities()
        {
            return _mapper.Map<List<CompanyDto>>(await _repository.List(new NotDeleatedSpec()));
        }
        public async Task<List<CompanyLightDto>> GetLightEntities()
        {
            var companies = await _repository.List(new CompanyInculdeTypeSpecification());

            return _mapper.Map<List<CompanyLightDto>>(companies);
        }
        public async Task<CompanyDto> GetEntity(int id)
        {
            var company = await _repository.GetSingleBySpec(new CompanyGetByIdAndIncludeAllSpecification(id));
            return _mapper.Map<CompanyDto>(company);
        }
        public async Task<CompanyDto> UpdateEntity(int id, CompanyDto dto)
        {
            var entity = await _repository.GetById(id);
            _mapper.Map(dto, entity);
            await _repository.Update(entity);
            return _mapper.Map<CompanyDto>(entity);
        }
        public async Task<CompanyCPMDto> UpdateEntity(int id, CompanyCPMDto dto)
        {
            var entity = await _repository.GetSingleBySpec(new CompanyGetByIdSpecification(id));
            if (entity != null)
            {
                _mapper.Map(dto, entity);
                await _repository.Update(entity);
            }

            return _mapper.Map<CompanyCPMDto>(entity);

        }
        public async Task<CompanyDto> AddEntity(CompanyDto dto)
        {
            var entity = _mapper.Map<Company>(dto);

            await _repository.Add(entity);

            return _mapper.Map<CompanyDto>(entity);
        }
        public async Task<CompanyDto> DeleteEntity(int id)
        {
            var entity = await _repository.GetSingleBySpec(new CompanyGetByIdSpecification(id));
            if (entity != null)
            {
                entity.IsDeleted = true;
                await _repository.Update(entity);
            }

            return _mapper.Map<CompanyDto>(entity);
        }
    }
}
