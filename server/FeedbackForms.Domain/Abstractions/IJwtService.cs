using FeedbackForms.Domain.Models;

namespace FeedbackForms.Domain.Abstractions;

public interface IJwtService
{
    public string GenerateToken(User user);
}

