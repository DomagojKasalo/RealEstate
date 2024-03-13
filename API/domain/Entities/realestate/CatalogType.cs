using System.Collections.Generic;
using domain.Entities.common;

namespace domain.Entities.releastate
{
    public class CatalogType : BaseEntity
    {
        public CatalogType()
        {
            Catalogs = new HashSet<Catalog>();
        }
        public string Name { get; set; }

        //Table Sets
        public virtual ICollection<Catalog> Catalogs { get; set; }
    }
}
