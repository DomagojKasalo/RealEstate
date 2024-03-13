using domain.Entities.crm;
using domain.Entities.releastate;

namespace application.Specifications.cpm
{
    public sealed class NotDeletedRealEstateCatalogSpec : BaseSpecification<Catalog>
    {
        public NotDeletedRealEstateCatalogSpec(int? companyId)
        {
            Criteria = i => i.IsDeleted == false && i.CompanyId == companyId;

            AddInclude(u => u.CatalogItems);
            AddInclude(u => u.Company);
            AddInclude(u => u.CatalogType);
        }
    }
    public sealed class AllRealEstateCatalogSpec : BaseSpecification<Catalog>
    {
        public AllRealEstateCatalogSpec()
        {
            Criteria = i => i.IsDeleted == false;

            AddInclude(u => u.CatalogItems);
            AddInclude(u => u.Company);
            AddInclude(u => u.CatalogType);
        }
    }
    public sealed class RealEstateCatalogGetByIdAndIncludeAllSpecification : BaseSpecification<Catalog>
    {
        public RealEstateCatalogGetByIdAndIncludeAllSpecification(int id)
        {
            Criteria = i => i.Id == id && i.IsDeleted == false;

            AddInclude(u => u.Company);
        }
    }
    public sealed class CatalogItemSpecification : BaseSpecification<CatalogItem>
    {
        public CatalogItemSpecification(int id)
        {
            Criteria = i => i.CatalogId == id && i.IsDeleted == false;

            AddInclude(u => u.Catalog.Company);
        }
    }
    public sealed class RealEstateCatalogGetByIdSpecification : BaseSpecification<Catalog>
    {
        public RealEstateCatalogGetByIdSpecification(int id)
        {
            Criteria = i => i.Id == id && i.IsDeleted == false;

            AddInclude(u => u.CatalogItems);
        }
    }
    public sealed class NotDeleatedCatalogSpec : BaseSpecification<Catalog>
    {
        public NotDeleatedCatalogSpec()
        {
            Criteria = i => i.IsDeleted == false;

            AddInclude(u => u.CatalogItems);
            AddInclude(u => u.Company);
            AddInclude(u => u.CatalogType);
        }
    }
}