using System;
using domain.Dto.common;

namespace domain.Dto.crm
{
    public class CompanyCPMDto : BaseDto
    {
        //public int StatusId { get; set; }
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public string? WebSite { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? BillingAddress { get; set; }
        public string? BillingZip { get; set; }
        public string? GID { get; set; }
        public string? GVAT { get; set; }
        public string? Fax { get; set; }
        public string? CompanyAcronym { get; set; }


    }
}
