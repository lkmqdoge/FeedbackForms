using FeedbackForms.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeedbackForms.Infrastructure.Configurations;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.HasKey(e => e.Id);
        builder
            .HasOne(e => e.Topic)
            .WithMany(e => e.Answers)
            .HasForeignKey(e => e.TopicId)
            .IsRequired();
    }
}

