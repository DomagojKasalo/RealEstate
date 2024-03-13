using domain.Entities.releastate;

namespace application.Specifications.cpm
{
    public sealed class NotDeletedRealestateCatalogItemSpec : BaseSpecification<CatalogItem>
    {
        public NotDeletedRealestateCatalogItemSpec(int? companyId)
        {
            Criteria = i => i.IsDeleted == false && i.Catalog.CompanyId == companyId; ;

            AddInclude(u => u.Catalog);
            AddInclude(u => u.Catalog.Company);
            AddInclude(u => u.CatalogItemStatus);
            AddInclude(u => u.CatalogItemType);
        }
    }
    public sealed class AllRealestateCatalogItemSpec : BaseSpecification<CatalogItem>
    {
        public AllRealestateCatalogItemSpec()
        {
            Criteria = i => i.IsDeleted == false;

            AddInclude(u => u.Catalog);
            AddInclude(u => u.Catalog.Company);
            AddInclude(u => u.CatalogItemStatus);
            AddInclude(u => u.CatalogItemType);
        }
    }
    public sealed class RealestateCatalogItemGetByIdAndIncludeAllSpecification : BaseSpecification<CatalogItem>
    {
        public RealestateCatalogItemGetByIdAndIncludeAllSpecification(int id)
        {
            Criteria = i => i.Id == id && i.IsDeleted == false;

            AddInclude(u => u.Catalog);
            AddInclude(u => u.Catalog.Company);
            AddInclude(u => u.CatalogItemStatus);
            AddInclude(u => u.CatalogItemType);
        }
    }
    public sealed class RealestateCatalogItemGetByIdSpecification : BaseSpecification<CatalogItem>
    {
        public RealestateCatalogItemGetByIdSpecification(int id)
        {
            Criteria = i => i.Id == id && i.IsDeleted == false;
        }
    }
    public sealed class NotDeleatedCatalogItemSpec : BaseSpecification<CatalogItem>
    {
        public NotDeleatedCatalogItemSpec()
        {
            Criteria = i => i.IsDeleted == false;

            AddInclude(u => u.Catalog);
            AddInclude(u => u.Catalog.Company);
            AddInclude(u => u.CatalogItemStatus);
            AddInclude(u => u.CatalogItemType);
        }
    }
    public sealed class CatalogItemWithRelatedSpecification : BaseSpecification<CatalogItem>
    {
        public CatalogItemWithRelatedSpecification(string search, int page, int pageSize)
            : base()
        {
            if (!string.IsNullOrEmpty(search))
            {
                Criteria = item => item.Name.ToLower().Contains(search.ToLower());
            }
            else
            {
                Criteria = item => true;
            }

            ApplyPaging((page - 1) * pageSize, pageSize);

            AddInclude(item => item.Catalog);
            AddInclude(item => item.Catalog.Company);
            AddInclude(item => item.CatalogItemStatus);
            AddInclude(item => item.CatalogItemType);
        }
    }
}
