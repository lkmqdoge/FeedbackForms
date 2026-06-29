namespace FeedbackForms.Domain;

public class AuthSettings
{
    public TimeSpan Expires { get; set; }
    public string SecretKey { get; set; } = string.Empty;
}