namespace FeedbackForms.Domain.Abstractions;
public interface ITurnstileService
{
    Task<bool> ValidateTokenAsync(string token, string? remoteIp = null);
}
