using domain.Dto.relestate;
using domain.Entities.common;
using domain.Entities.realestate;

namespace domain.Entities.releastate
{
    public class CatalogItem : BaseEntity
    {
        public CatalogItem()
        {
            CatalogItemImages = new HashSet<CatalogItemImage>();
        }
        //Database Atributes
        public int CatalogId { get; set; }
        public string? Name { get; set; }
        public Guid VersionIdentifier { get; set; }
        public string? Quote { get; set; }
        public string? Description { get; set; }
        public float? Floors { get; set; } //Broj katova kod kuće
        public int? Rooms { get; set; }
        public int? Bathrooms { get; set; }
        public int? GaragePlaces { get; set; }
        public string? Lamella { get; set; }
        public int? Floor { get; set; } //Broj kat u zgradi na kojem je stan
        public int? Units { get; set; } //Broj etaza u stanu

        public string? Dimensions { get; set; }
        public float? NetArea { get; set; }
        public float? BruttoArea { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsFeatured { get; set; }

        public int? CatalogItemTypeId { get; set; }
        public int? CatalogItemStatusId { get; set; }


        public string? Disclaimer { get; set; }
        public bool? IsDisclamer { get; set; }
        public string? ApprovedUser { get; set; }
        public int? DeploymentStatusId { get; set; }



        //Referent tables
        public virtual Catalog? Catalog { get; set; }
        public virtual CatalogItemType? CatalogItemType { get; set; }
        public virtual CatalogItemStatus? CatalogItemStatus { get; set; }
        public virtual DeploymentStatus? DeploymentStatus { get; set; }

        public virtual ICollection<CatalogItemImage> CatalogItemImages { get; set; } = new List<CatalogItemImage>();

    }
}
