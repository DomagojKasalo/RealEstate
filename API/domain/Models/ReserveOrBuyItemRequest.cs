using domain.Entities.users;

namespace domain.Models
{
    public class ReserveOrBuyItemRequest
    {
        public int ItemId { get; set; }
        public CatalogItemAction Action { get; set; }
        public User? User { get; set; }
    }
}
