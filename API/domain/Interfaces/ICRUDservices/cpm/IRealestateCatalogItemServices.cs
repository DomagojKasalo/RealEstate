using System.Threading.Tasks;
using domain.Dto.relestate;
using domain.Interfaces.ICRUDservices.common;

namespace domain.Interfaces.ICRUDservices.cpm
{
    public interface IRealestateCatalogItemServices : IBaseCRUDServices<RealEstateCatalogItemDto>
    {
        Task<List<RealEstateCatalogItemDto>> GetAllEntities();
        Task<RealEstateCatalogItemDto> UpdateIsEnabledCatalogItem(int catalogItemId, bool isEnabledValue);
        Task<RealEstateCatalogItemDto> UpdateIsFeaturedCatalogItem(int catalogItemId, bool isFeaturedValue); 
        Task<RealEstateCatalogItemDto> UpdateIsDisclamerCatalogItem(int catalogItemId, bool isDisclamerValue);
        Task<RealEstateCatalogItemDto> GetFilteredRealestateCatalogItemsAsync(int page = 1, int pageSize = 10, string search = "");
    }
}
