using domain.Dto.relestate;
using domain.Interfaces.ICRUDservices.common;

namespace domain.Interfaces.ICRUDservices.cpm
{
    public interface IRealestateCatalogServices : IBaseCRUDServices<RealEstateCatalogDto>
    {
        Task<List<RealEstateCatalogDto>> GetAllEntities();
        Task<List<RealEstateCatalogItemDto>> GetCatalogCatalogItems(int id);
        Task<RealEstateCatalogDto> UpdateIsEnabledCatalog(int catalogId, bool isEnabledValue);
    }
}
