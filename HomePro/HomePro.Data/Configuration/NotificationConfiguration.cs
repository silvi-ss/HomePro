using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HomePro.Data.Models;
using HomePro.Common;

namespace HomePro.Data.Configuration
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            // Primary Key
            builder.HasKey(n => n.Id);

            // CreatedOn
            builder
                .Property(n => n.CreatedOn)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasComment("Date and time when the notification was created");

            // ModifiedOn
            builder
                .Property(n => n.ModifiedOn)
                .HasColumnType("datetime2")
                .HasComment("Date and time when the notification was last modified");

            // IsDeleted
            builder
                .Property(n => n.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("Indicates whether the notification is deleted");

            // Title
            builder
                .Property(n => n.Title)
                .HasMaxLength(EntityValidationConstants.Notification.TitleMaxLength)
                .IsRequired()
                .HasComment("Title of the notification");

            // Message
            builder
                .Property(n => n.Message)
                .HasMaxLength(EntityValidationConstants.Notification.MessageMaxLength)
                .IsRequired()
                .HasComment("Message content of the notification");

            // UserId
            builder
                .Property(n => n.ClientId)
                .IsRequired()
                .HasComment("The ID of the user who will receive the notification");

            // IsRead
            builder
                .Property(n => n.IsRead)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("Indicates whether the notification is read");

            // Type
            builder
                .Property(n => n.Type)
                .IsRequired()
                .HasComment("Type of the notification");
        }
    }
}
