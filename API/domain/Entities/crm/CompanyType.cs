using System.Collections.Generic;
using domain.Entities.common;
using domain.Entities.crm;

namespace domain.Entities.crm
{
    public class CompanyType : BaseEntity
    {
        public CompanyType()
        {
            Companies = new HashSet<Company>();
        }

        //Database Atributes
        public string Name { get; set; }

        //Table Sets
        public virtual ICollection<Company> Companies { get; set; }

    }
}
