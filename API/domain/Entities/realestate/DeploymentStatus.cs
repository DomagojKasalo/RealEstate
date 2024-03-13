using domain.Entities.common;

namespace domain.Entities.releastate
{
    public class DeploymentStatus : BaseEntity
    {
        public DeploymentStatus()
        {
            CatalogItems = new HashSet<CatalogItem>();
        }

        //Database Atributes
        public string Name { get; set; }

        //Table Sets
        public virtual ICollection<CatalogItem> CatalogItems { get; set; }
    }
}
