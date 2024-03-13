using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using domain.Entities.users;
using Microsoft.AspNetCore.Identity;
using Crm = domain.Entities.crm;
using crm = persistance.Configuration.crm;
using Realestate = domain.Entities.releastate;
using realestate = persistance.Configuration.realestate;
using domain.Entities.email;
using domain.Entities.realestate;

namespace persistance.Datacontext
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Crm.Company> Companies { get; set; }
        public virtual DbSet<Crm.CompanyType> CompanyTypes { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }

        public virtual DbSet<Realestate.Catalog> RealestateCatalogs { get; set; }
        public virtual DbSet<Realestate.CatalogItem> RealestateCatalogItems { get; set; }
        public virtual DbSet<Realestate.CatalogPeriod> RealestateCatalogPeriods { get; set; }
        public virtual DbSet<Realestate.CatalogType> CatalogTypes { get; set; }
        public virtual DbSet<Realestate.CatalogItemType> CatalogItemTypes { get; set; }
        public virtual DbSet<Realestate.CatalogItemStatus> CatalogItemStatus { get; set; }
        public virtual DbSet<Realestate.DeploymentStatus> DeploymentStatuses { get; set; }
        public virtual DbSet<CatalogItemImage> CatalogItemImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entities using modelBuilder.Entity<T>() and Fluent API
            // Example:
            // modelBuilder.Entity<YourEntity>().Property(e => e.PropertyName).IsRequired();

            modelBuilder.ApplyConfiguration(new crm.CompanyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new crm.CompanyConfiguration());

            modelBuilder.Entity<Invitation>()
                .HasKey(i => i.Id);

            modelBuilder.ApplyConfiguration(new realestate.CatalogConfiguration());
            modelBuilder.ApplyConfiguration(new realestate.CatalogItemConfiguration());
            modelBuilder.ApplyConfiguration(new realestate.CatalogPeriodConfiguration());
            modelBuilder.ApplyConfiguration(new realestate.CatalogItemTypeConfiguration());
            modelBuilder.ApplyConfiguration(new realestate.CatalogTypeConfiguration());
            modelBuilder.ApplyConfiguration(new realestate.CatalogItemStatusConfiguration());
            modelBuilder.ApplyConfiguration(new realestate.DeploynebtStatusConfiguration());
            modelBuilder.ApplyConfiguration(new realestate.CatalogItemImageConfiguration());

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("Roles");
            });

        }
    }
}
