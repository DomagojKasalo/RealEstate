using domain.Dto.crm;
using domain.Interfaces.ICRUDservices.common;

namespace domain.Interfaces.ICRUDservices.crm
{
    public interface ICompanyServices : IBaseCRUDServices<CompanyDto>
    {
        Task<List<CompanyLightDto>> GetLightEntities();
        Task<CompanyCPMDto> UpdateEntity(int id, CompanyCPMDto dto);

    }
}
