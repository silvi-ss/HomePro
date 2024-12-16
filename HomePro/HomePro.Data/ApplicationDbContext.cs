using HomePro.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HomePro.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {

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

            var configTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract
                        && t.GetInterfaces()
                            .Any(i => i.IsGenericType
                             && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (var type in configTypes)
            {
                var config = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration((dynamic)config);
            }


        }
    }

}

