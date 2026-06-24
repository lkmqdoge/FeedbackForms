namespace FeedbackForms.Domain.Models;

public record Form(
    Guid Id,
    string Username,
    string Email,
    string Text
);