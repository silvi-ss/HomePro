using HomePro.Common;
using HomePro.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomePro.Data.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Title)
                   .IsRequired()
                   .HasMaxLength(EntityValidationConstants.Notification.TitleMaxLength);

            builder.Property(n => n.Message)
                   .IsRequired()
                   .HasMaxLength(EntityValidationConstants.Notification.MessageMaxLength);

            builder.HasOne(n => n.Client)
                   .WithMany()
                   .HasForeignKey(n => n.ClientId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(n => n.ServiceRequest)
                   .WithMany()
                   .HasForeignKey(n => n.ServiceRequestId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
