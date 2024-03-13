using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using domain.Entities.common;
using domain.Entities.crm;

namespace domain.Entities.releastate
{
    public class Catalog : BaseEntity
    {
        public Catalog()
        {
            CatalogItems = new HashSet<CatalogItem>();
            CatalogPeriods = new HashSet<CatalogPeriod>();
        }
        //Database Atributes
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public string? Quote { get; set; }
        public string? Description { get; set; }
        public int? CatalogTypeId {get;set;}
        public bool? IsEnabled { get; set; }


        //Referent tables
        public virtual Company Company { get; set; }
        public virtual CatalogType CatalogType { get; set; }

        //Table Sets
        public virtual ICollection<CatalogItem> CatalogItems { get; set; }
        public virtual ICollection<CatalogPeriod> CatalogPeriods { get; set; }
    }
}
