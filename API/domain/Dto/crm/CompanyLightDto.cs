using Microsoft.AspNetCore.Http;

namespace domain.Dto.crm
{
    public class CompanyLightDto
    {
        public int Id { get; set; }
        public string? CompanyType { get; set; }
        public string? CompanyName { get; set; }
        public string? WebSite { get; set; }
        public string? Email { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? ImagePath { get; set; }

    }
}
