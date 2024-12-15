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
        public virtual DbSet<Property> Properties { get; set; } = null!;

        public virtual DbSet<Address> Addresses { get; set; } = null!;

        public virtual DbSet<ServiceCatalog> ServiceCatalogs { get; set; } = null!;

        public virtual DbSet<ServiceRequest> ServiceRequests { get; set; } = null!; 

        public virtual DbSet<Notification> Notifications { get; set; } = null!;

        public virtual DbSet<ServiceReview> ServiceReviews { get; set; } = null!;

        public virtual DbSet<UserFavoriteService> UserFavoriteServices { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
