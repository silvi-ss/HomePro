using HomePro.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HomePro.Common;


namespace HomePro.Data.Configuration
{
    public class ServiceCatalogConfiguration : IEntityTypeConfiguration<ServiceCatalog>
    {
        public void Configure(EntityTypeBuilder<ServiceCatalog> builder)
        {
            builder.HasKey(s => s.Id);

            builder
                .Property(s => s.Name)
                .HasMaxLength(EntityValidationConstants.ServiceCatalog.NameMaxLength)
                .IsRequired()
                .HasComment("Name of the service");

            builder
                .Property(s => s.Description)
                .HasMaxLength(EntityValidationConstants.ServiceCatalog.DescriptionMaxLength)
                .IsRequired()
                .HasComment("Detailed description of the service");

            builder
               .Property(s => s.Image)
               .HasMaxLength(EntityValidationConstants.ServiceCatalog.ImageMaxLength)
               .HasDefaultValue(EntityValidationConstants.ServiceCatalog.DefaultImageName)
               .IsRequired(false)
               .HasComment("Service image file name");

            builder
                .Property(s => s.Type)
                .IsRequired()
                .HasComment("Type of service");

            builder
                .Property(s => s.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("Soft delete flag");

            builder
                .HasIndex(s => s.IsDeleted);
        }
    }
}
