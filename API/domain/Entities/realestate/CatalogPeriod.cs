using System;
using domain.Entities.common;

namespace domain.Entities.releastate
{
    public class CatalogPeriod : BaseEntity
    {
        //Database Atributes
        public int CatalogId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool Enabled { get; set; }

        //Referent tables
        public virtual Catalog? Catalog { get; set; }
    }
}
