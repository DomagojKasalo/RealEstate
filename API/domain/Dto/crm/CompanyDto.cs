using System;
using domain.Dto.common;
using Microsoft.AspNetCore.Http;

namespace domain.Dto.crm
{
    public class CompanyDto : BaseDto
    {
        public int? CompanyTypeId { get; set; }
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public string? WebSite { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? BillingAddress { get; set; }
        public string? ShipingAddress { get; set; }
        public string? BillingZip { get; set; }
        public string? ShipingZip { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string? GID { get; set; }
        public string? GVAT { get; set; }
        public string? Fax { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? ImagePath { get; set; }

        public string? CompanyTypeName { get; set; }
        public string? CompanyAcronym { get; set; }

    }
}
