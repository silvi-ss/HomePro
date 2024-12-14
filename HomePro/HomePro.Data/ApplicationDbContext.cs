using HomePro.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HomePro.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // TODO: Generate migrations after all entities are finalized!!!!!!!!!!!!
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {

        }
        public virtual DbSet<Property> Properties { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<ServiceCatalog> ServiceCatalogs { get; set; }

        public virtual DbSet<PropertyContract> PropertyContracts { get; set; }

        public DbSet<ServiceRequest> ServiceRequests { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
