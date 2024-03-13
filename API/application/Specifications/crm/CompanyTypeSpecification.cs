using System;
using System.Collections.Generic;
using System.Text;
using domain.Entities.crm;

namespace application.Specifications.crm
{
    public sealed class CompanyTypeSpecification : BaseSpecification<CompanyType>
    {
        public CompanyTypeSpecification(int id)
        {
            Criteria = i => i.Id == id && i.IsDeleted == false;
        }
    }
    public sealed class NotDeletedCompanyTypeSpec : BaseSpecification<CompanyType>
    {
        public NotDeletedCompanyTypeSpec()
        {
            Criteria = i => i.IsDeleted == false;
        }
    }
    public sealed class CompanyTypeGetByIdSpecification : BaseSpecification<CompanyType>
    {
        public CompanyTypeGetByIdSpecification(int id)
        {
            Criteria = i => i.Id == id && i.IsDeleted == false;
        }
    }
}
