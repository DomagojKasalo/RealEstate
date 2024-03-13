using System.Collections.Generic;
using domain.Entities.common;

namespace domain.Entities.releastate
{
    public class CatalogItemType : BaseEntity
    {
        public CatalogItemType()
        {
            CatalogItems = new HashSet<CatalogItem>();
        }

        //Database Atributes
        public string Name { get; set; }

        //Table Sets
        public virtual ICollection<CatalogItem> CatalogItems { get; set; }
    }
}
