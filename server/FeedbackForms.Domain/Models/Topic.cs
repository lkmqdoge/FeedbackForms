namespace FeedbackForms.Domain.Models;

public class Topic
{
    public Guid Id;

    public required string Title;

    public required string Body;

    public ICollection<Answer> Answers = [];

    public DateTime CreatedAt;
}

