using domain.Entities.crm;

namespace application.Specifications.crm
{
    public sealed class CompanyGetByIdAndIncludeAllSpecification : BaseSpecification<Company>
    {
        public CompanyGetByIdAndIncludeAllSpecification(int id)
        {
            Criteria = i => i.Id == id && i.IsDeleted == false;

            AddInclude(u => u.CompanyType);
        }
    }
    public sealed class CompanyGetByIdSpecification : BaseSpecification<Company>
    {
        public CompanyGetByIdSpecification(int id)
        {
            Criteria = i => i.Id == id && i.IsDeleted == false;
        }
    }
    public sealed class CompanyInculdeTypeSpecification : BaseSpecification<Company>
    {
        public CompanyInculdeTypeSpecification()
        {
            Criteria = i => i.IsDeleted == false;

            AddInclude(u => u.CompanyType);
        }
    }
    public sealed class NotDeleatedSpec : BaseSpecification<Company>
    {
        public NotDeleatedSpec()
        {
            Criteria = i => i.IsDeleted == false;
        }
    }
}
