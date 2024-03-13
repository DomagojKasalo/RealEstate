using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities.releastate;
using domain.Enums.realestate;

namespace persistance.Configuration.realestate
{
    class CatalogTypeConfiguration : IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogTypes", "realestate");

            builder.HasKey(c => c.Id);

            builder.HasMany(e => e.Catalogs)
               .WithOne(s => s.CatalogType)
               .HasForeignKey(d => d.CatalogTypeId)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("FK_Catalog_CatalogTypeId");

            SeedData(builder);
        }
        private static void SeedData(EntityTypeBuilder<CatalogType> builder)
        {
            builder.HasData(
                           new CatalogType { Id = (int)CatalogTypeEnum.House, Name = "House", CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CatalogType { Id = (int)CatalogTypeEnum.Building, Name = "Building", CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" });
        }
    }
}
