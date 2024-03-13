using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities.releastate;
using domain.Enums.realestate;

namespace persistance.Configuration.realestate
{
    class CatalogItemTypeConfiguration : IEntityTypeConfiguration<CatalogItemType>
    {
        public void Configure(EntityTypeBuilder<CatalogItemType> builder)
        {
            builder.ToTable("CatalogItemTypes", "realestate");

            builder.HasKey(c => c.Id);

            builder.HasMany(e => e.CatalogItems)
               .WithOne(s => s.CatalogItemType)
               .HasForeignKey(d => d.CatalogItemTypeId)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("FK_CatalogItem_CatalogItemTypeId");

            SeedData(builder);
        }
        private static void SeedData(EntityTypeBuilder<CatalogItemType> builder)
        {
            builder.HasData(
                           new CatalogItemType { Id = (int)CatalogItemTypeEnum.House, Name = "House", CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CatalogItemType {Id = (int)CatalogItemTypeEnum.Apartment, Name = "Apartment", CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CatalogItemType {Id = (int)CatalogItemTypeEnum.OfficeSpaces, Name = "Office Spaces", CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CatalogItemType {Id = (int)CatalogItemTypeEnum.BusinessSpaces, Name = "Business Spaces", CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CatalogItemType {Id = (int)CatalogItemTypeEnum.Building, Name = "Building", CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" }
                           );
        }
    }
}
