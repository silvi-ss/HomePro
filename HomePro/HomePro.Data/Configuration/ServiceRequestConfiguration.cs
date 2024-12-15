using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HomePro.Data.Models;
using HomePro.Common;

namespace HomePro.Data.Configuration
{
    public class ServiceRequestConfiguration : IEntityTypeConfiguration<ServiceRequest>
    {
        public void Configure(EntityTypeBuilder<ServiceRequest> builder)
        {
            builder.HasKey(sr => sr.Id);

            builder
                .HasOne(sr => sr.Property)
                .WithMany(p => p.ServiceRequests)
                .HasForeignKey(sr => sr.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(sr => sr.Client)
                .WithMany()
                .HasForeignKey(sr => sr.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                 .HasOne(sr => sr.ServiceCatalog)
                 .WithMany(sc => sc.ServiceRequests) 
                 .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(sr => sr.Frequency)
                .IsRequired()
                .HasComment("Frequency of the service request");

            builder
                .Property(sr => sr.CreatedOn)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasComment("Date and time when the service request was created");

            builder
                .Property(sr => sr.PreferredDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasComment("Preferred date for the service");

            builder
                .Property(sr => sr.Status)
                .IsRequired()
                .HasComment("Current status of the service request");

            builder
                .Property(sr => sr.IsCompleted)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("Indicates if the service request is completed");

            builder
                .Property(sr => sr.Description)
                .HasMaxLength(EntityValidationConstants.ServiceRequest.DescriptionMaxLength)
                .IsRequired(false)
                .HasComment("Additional description for the service request");

            builder
                .Property(sr => sr.FinalPrice)
                .HasPrecision(18, 2)
                .IsRequired()
                .HasComment("Final price of the service request");

            builder
                 .ToTable(t => t.HasCheckConstraint(
                     "CK_ServiceRequest_FinalPrice",
                     $"FinalPrice >= {EntityValidationConstants.ServiceRequest.MinPrice} " +
                     $"AND FinalPrice <= {EntityValidationConstants.ServiceRequest.MaxPrice}"));
        }
    }
}
