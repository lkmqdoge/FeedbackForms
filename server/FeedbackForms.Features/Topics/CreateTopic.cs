using FeedbackForms.Domain.Models;

using MediatR;

namespace FeedbackForms.Features.Topics;

public record CreateTopicRequest(string Title, string Body);

public record CreateTopicCommand(CreateTopicRequest Request)
    : IRequest<Guid>;

public record CreateTopicHandler()
    : IRequestHandler<CreateTopicCommand, Guid>
{
    public async Task<Guid> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var topic = new Topic
        {
            Id = Guid.NewGuid(),
            Title = request.Request.Title,
            Body = request.Request.Body,
            CreatedAt = DateTime.UtcNow
        };

        return topic.Id;
    }
}
