namespace FeedbackForms.Domain.Models;

public class Answer
{
    public Guid Id { get; set; }

    public required string UserName { get; set; }

    public required string Email { get; set; }

    public required string Text { get; set; }

    public Guid TopicId { get; set; }

    public Topic Topic { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
