using HomePro.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HomePro.Common;

namespace HomePro.Data.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                 .Property(u => u.FirstName)
                 .HasMaxLength(EntityValidationConstants.ApplicationUser.FirstNameMaxLength)
                 .IsRequired()
                 .HasComment("First name of the user");

            builder
                .Property(u => u.LastName)
                .HasMaxLength(EntityValidationConstants.ApplicationUser.LastNameMaxLength)
                .IsRequired()
                .HasComment("Last name of the user");

            builder
                .HasMany(u => u.Reviews)
                .WithOne(r => r.Client)
                .HasForeignKey(r => r.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(u => u.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("Soft delete flag");
            
            builder
                .HasIndex(u => u.IsDeleted);
        }
    }
}
