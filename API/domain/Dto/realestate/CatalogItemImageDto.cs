using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Dto.realestate
{
    public class CatalogItemImageDto
    {
        public int Id { get; set; }  // The Id if you need it
        public int CatalogItemId { get; set; }  // Foreign key to CatalogItem
        public string ImagePath { get; set; }  // Path to the image
    }

}
