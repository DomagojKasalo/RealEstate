using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities.releastate;
using domain.Entities.realestate;

namespace persistance.Configuration.realestate
{
    public class CatalogItemImageConfiguration : IEntityTypeConfiguration<CatalogItemImage>
    {
        public void Configure(EntityTypeBuilder<CatalogItemImage> builder)
        {
            builder.ToTable("CatalogItemImages", "realestate");

            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.CatalogItem)
                   .WithMany(c => c.CatalogItemImages)
                   .HasForeignKey(i => i.CatalogItemId);
        }
    }
}
