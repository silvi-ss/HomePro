namespace HomePro.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using HomePro.Data.Models;
    using HomePro.Common;


    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.DisplayName)
                .HasMaxLength(EntityValidationConstants.Property.DisplayNameMaxLength)
                .IsRequired()
                .HasComment("Display name of the property");

            builder
                .Property(p => p.SquareMeters)
                .IsRequired()
                .HasPrecision(18, 2)
                .HasComment("Property area in square meters");

            builder
                .Property(p => p.Rooms)
                .IsRequired()
                .HasComment("Number of rooms in the property");

            builder
                .Property(p => p.Description)
                .HasMaxLength(EntityValidationConstants.Property.DescriptionMaxLength)
                .IsRequired(false)
                .HasComment("Additional description for the property");

            builder
                .Property(p => p.Image)
                .HasMaxLength(EntityValidationConstants.Property.ImageMaxLength)
                .HasDefaultValue(EntityValidationConstants.Property.DefaultImageName)
                .IsRequired(false)
                .HasComment("Property image file name");

            builder
                .Property(p => p.CreatedOn)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValue(DateTime.UtcNow)
                .HasComment("Date and time of property creation");

            builder
                .Property(p => p.Type)
                .IsRequired()
                .HasComment("Type of property (Apartment, House, etc.)");

            builder
                .Property(p => p.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("Soft delete flag");

            // Relationships
            builder
                .HasOne(p => p.Owner)
                .WithMany()
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Address)
                .WithOne(a => a.Property)
                .HasForeignKey<Property>(p => p.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(p => p.PropertyContracts)
                .WithOne(pc => pc.Property)
                .HasForeignKey(pc => pc.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(p => p.ServiceRequests)
                .WithOne(sr => sr.Property)
                .HasForeignKey(sr => sr.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(p => p.IsDeleted);

            builder
                .HasIndex(p => p.OwnerId);

        }
    }
}
