namespace FeedbackForms.Features.Shared;

public record TopicDto(
    Guid Id,
    string Title,
    string Body,
    bool IsOwner
);