using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HomePro.Data.Models;
using HomePro.Common;

namespace HomePro.Data.Configuration
{
    public class UserFavoriteServiceConfiguration : IEntityTypeConfiguration<UserFavoriteService>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteService> builder)
        {
            builder.HasKey(fs => new { fs.UserId, fs.ServiceCatalogId });

            builder
                .Property(fs => fs.AddedOn)
                .IsRequired()
                .HasComment("Date when service was added to favorites");

            builder
                .Property(fs => fs.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("Soft delete flag");

            builder
                .HasOne(fs => fs.User)
                .WithMany(u => u.FavoriteServices)
                .HasForeignKey(fs => fs.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(fs => fs.Service)
                .WithMany(s => s.UserFavorites)
                .HasForeignKey(fs => fs.ServiceCatalogId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(fs => fs.IsDeleted);
        }
    }
}
