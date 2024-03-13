using domain.Entities.releastate;

namespace application.Specifications.cpm
{
    public sealed class NotDeletedCatalogItemTypeSpec : BaseSpecification<CatalogItemType>
    {
        public NotDeletedCatalogItemTypeSpec()
        {
            Criteria = i => i.IsDeleted == false;
        }
    }
    public sealed class CatalogItemTypeGetByIdAndIncludeAllSpecification : BaseSpecification<CatalogItemType>
    {
        public CatalogItemTypeGetByIdAndIncludeAllSpecification(int id)
        {
            Criteria = i => i.Id == id && i.IsDeleted == false;
        }
    }
}
