using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities.crm;
using domain.Enums.crm;

namespace persistance.Configuration.crm
{
    class CompanyTypeConfiguration : IEntityTypeConfiguration<CompanyType>
    {
        public void Configure(EntityTypeBuilder<CompanyType> builder)
        {
            builder.ToTable("CompanyTypes", "crm");

            builder.HasKey(c => c.Id);

            builder.HasMany(e => e.Companies)
               .WithOne(s => s.CompanyType)
               .HasForeignKey(d => d.CompanyTypeId)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("FK_Company_CompanyTypeId");


            SeedData(builder);
        }
        private static void SeedData(EntityTypeBuilder<CompanyType> builder)
        {
            builder.HasData(
                           new CompanyType { Id =(int)CompanyTypeEnum.Communications, Name = "Communications", CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CompanyType { Id =(int)CompanyTypeEnum.Technology, Name = "Technology", CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CompanyType { Id =(int)CompanyTypeEnum.GowermentMilitary, Name = "Gowerment Military", CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CompanyType { Id =(int)CompanyTypeEnum.Manufacturing, Name = "Manufacturing", CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CompanyType { Id =(int)CompanyTypeEnum.FinancialServices, Name = "Financial Services", CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CompanyType { Id =(int)CompanyTypeEnum.ITservices, Name = "IT services", CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CompanyType { Id =(int)CompanyTypeEnum.Education, Name = "Education", CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CompanyType { Id =(int)CompanyTypeEnum.RealEstate, Name = "Real Estate", CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CompanyType { Id =(int)CompanyTypeEnum.Consulting, Name = "Consulting", CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CompanyType { Id =(int)CompanyTypeEnum.Management, Name = "Management", CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new CompanyType { Id =(int)CompanyTypeEnum.Other, Name = "Other", CreatedDate = DateTime.Parse("01.01.2020"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2020"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" });
        }
    }
}
