using domain.Entities.releastate;

namespace application.Specifications.cpm
{
    public sealed class NotDeletedCatalogItemStatusSpec : BaseSpecification<CatalogItemStatus>
    {
        public NotDeletedCatalogItemStatusSpec()
        {
            Criteria = i => i.IsDeleted == false;
        }
    }
    public sealed class CatalogItemStatusGetByIdAndIncludeAllSpecification : BaseSpecification<CatalogItemStatus>
    {
        public CatalogItemStatusGetByIdAndIncludeAllSpecification(int id)
        {
            Criteria = i => i.Id == id && i.IsDeleted == false;
        }
    }
}
