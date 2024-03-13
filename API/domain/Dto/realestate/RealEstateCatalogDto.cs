using domain.Dto.common;

namespace domain.Dto.relestate
{
    public class RealEstateCatalogDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CompanyId { get; set; }
        public int CatalogTypeId { get; set; }
        public string? CatalogTypeName { get; set; }
        public string? CompanyName { get; set; }
        public bool? IsEnabled { get; set; }
    }
}
