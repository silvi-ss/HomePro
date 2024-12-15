using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HomePro.Data.Models;
using HomePro.Common;

public class ServiceReviewConfiguration : IEntityTypeConfiguration<ServiceReview>
{
    public void Configure(EntityTypeBuilder<ServiceReview> builder)
    {
        builder.HasKey(r => r.Id);

        builder
            .Property(r => r.Comment)
            .HasMaxLength(EntityValidationConstants.ServiceReview.CommentMaxLength)
            .IsRequired()
            .HasComment("Review comment");

        builder
            .Property(r => r.Rating)
            .IsRequired()
            .HasComment("Rating from 1 to 5");

        builder
            .Property(r => r.CreatedOn)
            .IsRequired()
            .HasComment("Date and time of review creation");

        builder
            .Property(r => r.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false)
            .HasComment("Soft delete flag");

       
        builder
            .HasOne(r => r.ServiceRequest)
            .WithMany(s => s.Reviews)
            .HasForeignKey(r => r.ServiceRequestId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(r => r.Client)
            .WithMany()
            .HasForeignKey(r => r.ClientId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasIndex(r => r.IsDeleted);
    }
}