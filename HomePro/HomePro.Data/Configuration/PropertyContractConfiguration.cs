using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HomePro.Data.Models;
using HomePro.Common;


namespace HomePro.Data.Configuration
{
    public class PropertyContractConfiguration : IEntityTypeConfiguration<PropertyContract>
    {
        public void Configure(EntityTypeBuilder<PropertyContract> builder)
        {
            builder.HasKey(pc => pc.Id);

            
            builder
                .Property(pc => pc.ContractNumber)
                .HasMaxLength(EntityValidationConstants.PropertyContract.ContractNumberMaxLength)
                .IsRequired()
                .HasComment("Unique contract number for the property");

          
            builder
                .Property(pc => pc.StartDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasComment("Start date of the property contract");

            
            builder
                .Property(pc => pc.EndDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasComment("End date of the property contract");

            
            builder
                .Property(pc => pc.MonthlyFee)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasComment("Monthly fee for the property contract");

           
            builder
                .Property(pc => pc.IsActive)
                .IsRequired()
                .HasDefaultValue(true)
                .HasComment("Indicates whether the contract is active");

            
            builder
                .HasOne(pc => pc.Property)
                .WithMany(p => p.PropertyContracts)
                .HasForeignKey(pc => pc.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

           
            builder
                .HasOne(pc => pc.Client)
                .WithMany() 
                .HasForeignKey(pc => pc.ClientId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
