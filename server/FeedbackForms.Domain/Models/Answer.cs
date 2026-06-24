namespace FeedbackForms.Domain.Models;

public class Answer
{
    public Guid Id;

    public required string UserName;

    public required string Email;

    public required string Text;

    public Guid TopicId;

    public required Topic Topic;

    public DateTime CreatedAt;
}

