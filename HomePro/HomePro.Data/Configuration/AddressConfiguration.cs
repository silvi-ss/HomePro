using HomePro.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HomePro.Common;



namespace HomePro.Data.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .Property(a => a.Country)
                .HasMaxLength(EntityValidationConstants.Address.CountryMaxLength)
                .IsRequired()
                .HasComment("Country of the address");

            builder
                .Property(a => a.City)
                .HasMaxLength(EntityValidationConstants.Address.CityMaxLength)
                .IsRequired()
                .HasComment("City of the address");

            builder
                .Property(a => a.District)
                .HasMaxLength(EntityValidationConstants.Address.DistrictMaxLength)
                .IsRequired(false)
                .HasComment("District or region of the address");

            builder
                .Property(a => a.StreetName)
                .HasMaxLength(EntityValidationConstants.Address.StreetNameMaxLength)
                .IsRequired()
                .HasComment("Street name of the address (if applicable)");

            builder
                .Property(a => a.StreetNumber)
                .HasMaxLength(EntityValidationConstants.Address.StreetNumberMaxLength)
                .IsRequired()
                .HasComment("Street number of the address");
                        
            builder
                .Property(a => a.BuildingNumber)
                .HasMaxLength(EntityValidationConstants.Address.BuildingNumberMaxLength)
                .IsRequired(false)
                .HasComment("Building number (if applicable)");
                       
            builder
                .Property(a => a.Floor)
                .HasMaxLength(EntityValidationConstants.Address.FloorMaxLength)
                .IsRequired(false)
                .HasComment("Floor number (if applicable)");

            builder
                .Property(a => a.Entry)
                .HasMaxLength(EntityValidationConstants.Address.EntryMaxLength)
                .IsRequired(false)
                .HasComment("Entry number (if applicable)");
                        
            builder
                .Property(a => a.PostalCode)
                .HasMaxLength(EntityValidationConstants.Address.PostalCodeMaxLength)
                .IsRequired()
                .HasComment("Postal code of the address");
                       
            builder
                .Property(a => a.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("Soft delete flag");

            builder
                .HasOne(a => a.Property)
                .WithOne(p => p.Address)
                .HasForeignKey<Address>(a => a.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
