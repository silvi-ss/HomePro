using HomePro.Data.Models;
using HomePro.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomePro.Data.Configurations
{
    public class ServiceRequestConfiguration : IEntityTypeConfiguration<ServiceRequest>
    {
        public void Configure(EntityTypeBuilder<ServiceRequest> builder)
        {
            builder.HasKey(sr => sr.Id);

            builder.Property(sr => sr.Description)
                   .HasMaxLength(EntityValidationConstants.ServiceRequest.DescriptionMaxLength);

            builder.Property(sr => sr.FinalPrice)
                   .HasPrecision(18, 2);

            builder.HasOne(sr => sr.Property)
                   .WithMany(p => p.ServiceRequests)
                   .HasForeignKey(sr => sr.PropertyId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(sr => sr.ServiceCatalog)
                   .WithMany(sc => sc.ServiceRequests)
                   .HasForeignKey(sr => sr.ServiceCatalogId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(sr => sr.Client)
                   .WithMany(u => u.ServiceRequests)
                   .HasForeignKey(sr => sr.ClientId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
