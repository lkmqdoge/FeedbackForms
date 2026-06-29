using FeedbackForms.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeedbackForms.Infrastructure.Configurations;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.HasKey(e => e.Id);
        builder
            .HasMany(e => e.Answers)
            .WithOne(e => e.Topic)
            .HasForeignKey(e => e.TopicId)
            .IsRequired();

        builder
            .HasOne(e => e.User)
            .WithMany(e => e.Topics)
            .HasForeignKey(e => e.UserId)
            .IsRequired();
    }
}
