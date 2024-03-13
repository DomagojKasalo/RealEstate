using System;
using domain.Dto.common;

namespace domain.Dto.realestate
{
    public class CatalogPeriodDto : BaseDto
    {
        public int CatalogId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool Enabled { get; set; }
        public string? CatalogName { get; set; }
    }
}
