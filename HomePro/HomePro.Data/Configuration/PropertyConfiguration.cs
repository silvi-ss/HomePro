using HomePro.Data.Models;
using HomePro.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomePro.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DisplayName)
                   .IsRequired()
                   .HasMaxLength(EntityValidationConstants.Property.DisplayNameMaxLength);

            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(EntityValidationConstants.Property.DescriptionMaxLength);

            builder.Property(p => p.SquareMeters)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.HasOne(p => p.Client)
                   .WithMany(u => u.Properties)
                   .HasForeignKey(p => p.ClientId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Address)
                   .WithOne(a => a.Property)
                   .HasForeignKey<Property>(p => p.AddressId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
