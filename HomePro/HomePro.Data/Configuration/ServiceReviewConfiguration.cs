using HomePro.Data.Models;
using HomePro.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomePro.Data.Configurations
{
    public class ServiceReviewConfiguration : IEntityTypeConfiguration<ServiceReview>
    {
        public void Configure(EntityTypeBuilder<ServiceReview> builder)
        {
            builder.HasKey(sr => sr.Id);

            builder.Property(sr => sr.Comment)
                   .IsRequired()
                   .HasMaxLength(EntityValidationConstants.ServiceReview.CommentMaxLength);

            builder.Property(sr => sr.Rating)
                   .IsRequired();

            builder.HasOne(sr => sr.Client)
                   .WithMany(u => u.Reviews)
                   .HasForeignKey(sr => sr.ClientId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(sr => sr.ServiceRequest)
                   .WithMany(srq => srq.Reviews)
                   .HasForeignKey(sr => sr.ServiceRequestId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
