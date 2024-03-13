using System;
using System.Collections.Generic;
using domain.Dto.crm;
using domain.Entities.common;
using domain.Entities.releastate;
using domain.Entities.users;

namespace domain.Entities.crm
{
    public class Company : BaseEntity
    {
        public Company()
        {
            Users = new HashSet<User>();
            Catalogs = new HashSet<Catalog>();
        }
        //Database Atributes
        //public int StatusId { get; set; }
        public int? CompanyTypeId { get; set; }
        public string? CompanyName { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? Description { get; set; }
        public string? Site { get; set; }
        public string? GID { get; set; }
        public string? GVAT { get; set; }
        public string? WebSite { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? BillingAddress { get; set; }
        public string? ShipingAddress { get; set; }
        public string? BillingZip { get; set; }
        public string? ShipingZip { get; set; }
        public string? Fax { get; set; }
        public string? CompanyAcronym { get; set; }
        public string? ImagePath { get; set; }
        //Referent table
        //public Catalog Catalog { get; set; }
        public virtual CompanyType CompanyType { get; set; }
        //Table Sets
        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Catalog>? Catalogs { get; set; }

    }
}
