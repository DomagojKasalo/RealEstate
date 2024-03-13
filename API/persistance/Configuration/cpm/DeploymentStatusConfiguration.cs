using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities.releastate;
using domain.Enums.realestate;

namespace persistance.Configuration.realestate
{
    class DeploynebtStatusConfiguration : IEntityTypeConfiguration<DeploymentStatus>
    {
        public void Configure(EntityTypeBuilder<DeploymentStatus> builder)
        {
            builder.ToTable("DeploymentStatuses", "realestate");

            builder.HasKey(c => c.Id);

            builder.HasMany(e => e.CatalogItems)
               .WithOne(s => s.DeploymentStatus)
               .HasForeignKey(d => d.DeploymentStatusId)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("FK_CatalogItem_CdeploymentStatusId");

            SeedData(builder);
        }
        private static void SeedData(EntityTypeBuilder<DeploymentStatus> builder)
        {
            builder.HasData(
                           new DeploymentStatus { Id = (int)DeploymentStatusEnum.UnderConstructionDevelopment, Name = "Under Construction (Development)", CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new DeploymentStatus { Id = (int)DeploymentStatusEnum.RequestApprovalStaging, Name = "Request Approval (Staging)", CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" },
                           new DeploymentStatus { Id = (int)DeploymentStatusEnum.Approved, Name = "Approved", CreatedDate = DateTime.Parse("01.01.2019"), CreatedUser = "d15b15be-0cdc-498d-817c-0b911da8d139", ModifiedDate = DateTime.Parse("01.01.2019"), ModifiedUser = "d15b15be-0cdc-498d-817c-0b911da8d139" });
        }
    }
}
