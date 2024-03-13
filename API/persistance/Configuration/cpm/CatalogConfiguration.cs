using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities.releastate;
using domain.Enums.realestate;

namespace persistance.Configuration.realestate
{
    class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.ToTable("Catalogs", "realestate");

            builder.HasKey(c => c.Id);

            builder.HasMany(e => e.CatalogItems)
                  .WithOne(s => s.Catalog)
                  .HasForeignKey(d => d.CatalogId)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_CatalogItem_CatalogId");

            builder.HasMany(e => e.CatalogPeriods)
                  .WithOne(s => s.Catalog)
                  .HasForeignKey(d => d.CatalogId)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_CatalogPeriod_CatalogId");

            SeedData(builder);
        }

        private static void SeedData(EntityTypeBuilder<Catalog> builder)
        {
            builder.HasData(
                           new Catalog { Id = 1, CompanyId = 1, Name = "Wooden house", CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is catalog description", CatalogTypeId = (int)CatalogTypeEnum.House },
                           new Catalog {Id = 2, CompanyId = 1, Name = "Winter house", CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is catalog description", CatalogTypeId = (int)CatalogTypeEnum.House },
                           new Catalog {Id = 3, CompanyId = 2, Name = "Modern house", CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is catalog description", CatalogTypeId = (int)CatalogTypeEnum.House },
                           new Catalog {Id = 4, CompanyId = 2, Name = "Buildings", CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is catalog description", CatalogTypeId = (int)CatalogTypeEnum.Building });
        }

    }
}
