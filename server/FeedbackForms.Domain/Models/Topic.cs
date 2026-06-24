namespace FeedbackForms.Domain.Models;

public class Topic
{
    public Guid Id { get; set; }

    public required string Title { get; set; }

    public required string Body { get; set; }

    public ICollection<Answer> Answers { get; set; } = [];

    public DateTime CreatedAt { get; set; }
}
