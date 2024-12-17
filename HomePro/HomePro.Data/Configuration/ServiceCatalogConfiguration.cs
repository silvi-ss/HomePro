using HomePro.Data.Models;
using HomePro.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomePro.Data.Configurations
{
    public class ServiceCatalogConfiguration : IEntityTypeConfiguration<ServiceCatalog>
    {
        public void Configure(EntityTypeBuilder<ServiceCatalog> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Name)
                   .IsRequired()
                   .HasMaxLength(EntityValidationConstants.ServiceCatalog.NameMaxLength);

            builder.Property(sc => sc.Description)
                   .IsRequired()
                   .HasMaxLength(EntityValidationConstants.ServiceCatalog.DescriptionMaxLength);

            builder.Property(sc => sc.Image)
                   .HasMaxLength(EntityValidationConstants.ServiceCatalog.ImageMaxLength);

            builder.HasMany(sc => sc.ServiceRequests)
                   .WithOne(sr => sr.ServiceCatalog)
                   .HasForeignKey(sr => sr.ServiceCatalogId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(sc => sc.UserFavorites)
                   .WithOne(uf => uf.Service)
                   .HasForeignKey(uf => uf.ServiceCatalogId)
                   .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
