using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using domain.Entities.branding;
using domain.Entities.crm;
using domain.Enums.crm;

namespace persistance.Configuration.crm
{
    class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company", "crm");

            builder.HasKey(c => c.Id);

            builder.HasMany(e => e.Users)
               .WithOne(s => s.Company)
               .HasForeignKey(d => d.CompanyId)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("FK_User_CompanyId");

            builder.HasMany(e => e.Catalogs)
               .WithOne(s => s.Company)
               .HasForeignKey(d => d.CompanyId)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("FK_Catalog_CompanyId");

            SeedData(builder);
        }

        private static void SeedData(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                           new Company { Id = 1, CompanyTypeId = (int)CompanyTypeEnum.ITservices, CompanyName = "COX4", Description = "", WebSite = "cox4.eu", Phone = "", Email = "info@cox4.eu", BillingAddress = "Kralja Petra Kresimira 4", ShipingAddress = "Blajburskih zrtava 19c", BillingZip = "88000", ShipingZip = "88000", CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", CompanyAcronym = "COX4" },
                           new Company { Id = 2, CompanyTypeId = (int)CompanyTypeEnum.Technology, CompanyName = "MSS", Description = "", WebSite = "mss.eu", Phone = "", Email = "info@cox4.eu", BillingAddress = "Splitska 10", ShipingAddress = "Splitska10", BillingZip = "88000", ShipingZip = "88000", CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", CompanyAcronym = "MSS" });
        }
    }
}
