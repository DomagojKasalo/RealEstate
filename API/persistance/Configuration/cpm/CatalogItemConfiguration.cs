using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using domain.Entities.releastate;
using domain.Enums.realestate;
using AutoMapper;

namespace persistance.Configuration.realestate
{
    class CatalogItemConfiguration : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("CatalogItems", "realestate");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.VersionIdentifier).IsUnique();

            builder.HasMany(c => c.CatalogItemImages)
                   .WithOne(i => i.CatalogItem)
                   .HasForeignKey(i => i.CatalogItemId)
                   .OnDelete(DeleteBehavior.Cascade);

            SeedData(builder);
        }

        private static void SeedData(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.HasData(
                           new CatalogItem { Id = 1, CatalogId = 1, Name = "CatalogItems-WoodenHouse1", VersionIdentifier = new Guid("c8248327-2c41-47f2-b09f-a198eb10f58b"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description",  },
                           new CatalogItem {Id = 2, CatalogId = 1, Name = "CatalogItems-WoodenHouse2", VersionIdentifier = new Guid("c2c1c5ae-4433-4cbd-8a61-c4c67575b431"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description" },
                           new CatalogItem {Id = 3, CatalogId = 1, Name = "CatalogItems-WoodenHouse3", VersionIdentifier = new Guid("ff4c6d79-fdb7-4673-b850-a762bf3c5a4a"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description" },
                           new CatalogItem {Id = 4, CatalogId = 1, Name = "CatalogItems-WoodenHouse4", VersionIdentifier = new Guid("ee82569a-1410-4ec2-b499-ba16ecdb3fd4"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description" },
                           new CatalogItem {Id = 5, CatalogId = 2, Name = "CatalogItems-WinterHouse1", VersionIdentifier = new Guid("33d551e5-4886-4606-a5e1-8048bec6b6ba"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description" },
                           new CatalogItem {Id = 6, CatalogId = 2, Name = "CatalogItems-WinterHouse2", VersionIdentifier = new Guid("ea1fe074-c291-4c76-b921-62dfcd5c15a8"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description" },
                           new CatalogItem {Id = 7, CatalogId = 2, Name = "CatalogItems-WinterHouse3", VersionIdentifier = new Guid("4bacb9ce-8b8c-4cac-80ed-1ed0b84ea956"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description" },
                           new CatalogItem {Id = 8, CatalogId = 2, Name = "CatalogItems-WinterHouse4", VersionIdentifier = new Guid("84fe72dc-948f-4b06-bc27-18ed8646029c"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description" },
                           new CatalogItem {Id = 9, CatalogId = 3, Name = "CatalogItems-ModernHouse1", VersionIdentifier = new Guid("3b1cb6d5-31da-47b9-a0f5-1b81aebfb524"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description" },
                           new CatalogItem {Id = 10, CatalogId = 3, Name = "CatalogItems-ModernHouse2", VersionIdentifier = new Guid("55fb6804-2cbf-496a-a1c0-3d9882d3794a"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description" },
                           new CatalogItem {Id = 11, CatalogId = 3, Name = "CatalogItems-ModernHouse3", VersionIdentifier = new Guid("4d04a47b-128c-4b21-87df-f443cbf9d874"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description" },
                           new CatalogItem {Id = 12, CatalogId = 3, Name = "CatalogItems-ModernHouse4", VersionIdentifier = new Guid("776f3702-31b9-43a4-b168-6e3f20a931f8"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description" },
                           new CatalogItem {Id = 13, CatalogId = 4, Name = "CatalogItems-Buildings1", VersionIdentifier = new Guid("1859b32e-f3d0-459a-912b-714e411db2f7"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description" },
                           new CatalogItem {Id = 14, CatalogId = 4, Name = "CatalogItems-Buildings2", VersionIdentifier = new Guid("7d8834f8-826b-42ec-b6df-4226a8e3b5eb"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description" },
                           new CatalogItem {Id = 15, CatalogId = 4, Name = "CatalogItems-Buildings3", VersionIdentifier = new Guid("95f45a7c-3fcf-4db4-a023-cd6ad40a1014"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description" },
                           new CatalogItem {Id = 16, CatalogId = 4, Name = "CatalogItems-Buildings4", VersionIdentifier = new Guid("5674b573-b0de-4dd8-9507-85c875be5b65"), CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "1", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "1", Quote = "Wait...", Description = "This is description" });
        }
    }
}
