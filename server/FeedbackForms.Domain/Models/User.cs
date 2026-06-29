namespace FeedbackForms.Domain.Models;

public class User
{
    public Guid Id { get; set; }

    public required string UserName { get; set; }

    public required string Email { get; set; }

    public string HashedPassword { get; set; } = null!;

    public ICollection<Topic> Topics { get; set; } = [];

    public DateTime CreatedAt { get; set; }
}

