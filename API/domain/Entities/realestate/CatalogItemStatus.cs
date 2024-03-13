using System.Collections.Generic;
using domain.Entities.common;

namespace domain.Entities.releastate
{
    public class CatalogItemStatus : BaseEntity
    {
        public CatalogItemStatus()
        {
            CatalogItems = new HashSet<CatalogItem>();
        }

        //Database Atributes
        public string Name { get; set; }
        public string Color { get; set; }

        //Table Sets
        public virtual ICollection<CatalogItem> CatalogItems { get; set; }
    }
}
