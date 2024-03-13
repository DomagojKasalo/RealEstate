using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities.releastate;
using domain.Enums.realestate;

namespace persistance.Configuration.realestate
{
    class CatalogItemStatusConfiguration : IEntityTypeConfiguration<CatalogItemStatus>
    {
        public void Configure(EntityTypeBuilder<CatalogItemStatus> builder)
        {
            builder.ToTable("CatalogItemStatuses", "realestate");

            builder.HasKey(c => c.Id);

            builder.HasMany(e => e.CatalogItems)
               .WithOne(s => s.CatalogItemStatus)
               .HasForeignKey(d => d.CatalogItemStatusId)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("FK_CatalogItem_CatalogItemStatusId");

            SeedData(builder);
        }
        private static void SeedData(EntityTypeBuilder<CatalogItemStatus> builder)
        {
            builder.HasData(
                           new CatalogItemStatus { Id = (int)CatalogItemStatusEnum.Available, Color= "#00FF14",  Name = "Available", CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CatalogItemStatus { Id = (int)CatalogItemStatusEnum.Reserved, Color = "#F2FF00", Name = "Reserved",CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CatalogItemStatus { Id = (int)CatalogItemStatusEnum.SoldOut, Color = "#FF0000", Name = "Sold Out", CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" });
        }
    }
}
