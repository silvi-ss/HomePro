using HomePro.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomePro.Data.Configurations
{
    public class UserFavoriteServiceConfiguration : IEntityTypeConfiguration<UserFavoriteService>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteService> builder)
        {
            builder.HasKey(ufs => new { ufs.UserId, ufs.ServiceCatalogId }); 

            builder.HasOne(ufs => ufs.User)
                   .WithMany(u => u.FavoriteServices)
                   .HasForeignKey(ufs => ufs.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ufs => ufs.Service)
                   .WithMany(sc => sc.UserFavorites)
                   .HasForeignKey(ufs => ufs.ServiceCatalogId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
