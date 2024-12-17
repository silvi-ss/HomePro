using HomePro.Data.Models;
using HomePro.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomePro.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Country)
                   .IsRequired()
                   .HasMaxLength(EntityValidationConstants.Address.CountryMaxLength);

            builder.Property(a => a.City)
                   .IsRequired()
                   .HasMaxLength(EntityValidationConstants.Address.CityMaxLength);

            builder.Property(a => a.District)
                   .HasMaxLength(EntityValidationConstants.Address.DistrictMaxLength);

            builder.Property(a => a.StreetName)
                   .IsRequired()
                   .HasMaxLength(EntityValidationConstants.Address.StreetNameMaxLength);

            builder.Property(a => a.StreetNumber)
                   .HasMaxLength(EntityValidationConstants.Address.StreetNumberMaxLength);

            builder.Property(a => a.PostalCode)
                   .IsRequired()
                   .HasMaxLength(EntityValidationConstants.Address.PostalCodeMaxLength);

            builder.HasOne(a => a.Property)
                   .WithOne(p => p.Address)
                   .HasForeignKey<Address>(a => a.PropertyId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
