using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities.releastate;

namespace persistance.Configuration.realestate
{
    class CatalogPeriodConfiguration : IEntityTypeConfiguration<CatalogPeriod>
    {
        public void Configure(EntityTypeBuilder<CatalogPeriod> builder)
        {
            builder.ToTable("CatalogPeriods", "realestate");

            builder.HasKey(c => c.Id);

            SeedData(builder);
        }
        private static void SeedData(EntityTypeBuilder<CatalogPeriod> builder)
        {
            builder.HasData(
                           new CatalogPeriod { Id = 1, CatalogId = 1, DateFrom = DateTime.Parse("01.01.2019"), DateTo = DateTime.Parse("01.01.2019"), Enabled = true, CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "1" },
                           new CatalogPeriod { Id = 2, CatalogId = 2, DateFrom = DateTime.Parse("01.01.2019"), DateTo = DateTime.Parse("01.01.2019"), Enabled = true, CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "1" },
                           new CatalogPeriod { Id = 3, CatalogId = 1, DateFrom = DateTime.Parse("01.01.2019"), DateTo = DateTime.Parse("01.01.2019"), Enabled = true, CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "1" },
                           new CatalogPeriod { Id = 4, CatalogId = 2, DateFrom = DateTime.Parse("01.01.2019"), DateTo = DateTime.Parse("01.01.2019"), Enabled = true, CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "1" });
        }
    }
}
