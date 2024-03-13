using domain.Entities.common;
using domain.Entities.releastate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities.realestate
{
    public class CatalogItemImage : BaseEntity
    {
        public int CatalogItemId { get; set; }  // Foreign key to CatalogItem
        public string ImagePath { get; set; }  // Path to the image

        public virtual CatalogItem CatalogItem { get; set; }  // Navigation property
    }
}
