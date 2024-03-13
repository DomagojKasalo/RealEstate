using domain.Dto.relestate;
using domain.Entities.users;

namespace domain.Models
{
    public class SendReservationOrPurchaseEmailRequest
    {
        public User? User { get; set; }
        public RealEstateCatalogItemDto? CatalogItem { get; set; }
        public string? Email { get; set; }
        public CatalogItemAction Action { get; set; }
    }

    public enum CatalogItemAction
    {
        Reserved,
        Purchased
    }

}
