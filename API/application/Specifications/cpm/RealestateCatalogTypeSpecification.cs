using domain.Entities.releastate;

namespace application.Specifications.cpm
{
    public sealed class NotDeletedCatalogTypeSpec : BaseSpecification<CatalogType>
    {
        public NotDeletedCatalogTypeSpec()
        {
            Criteria = i => i.IsDeleted == false;
        }
    }
    public sealed class CatalogTypeGetByIdAndIncludeAllSpecification : BaseSpecification<CatalogType>
    {
        public CatalogTypeGetByIdAndIncludeAllSpecification(int id)
        {
            Criteria = i => i.Id == id && i.IsDeleted == false;
        }
    }
}
