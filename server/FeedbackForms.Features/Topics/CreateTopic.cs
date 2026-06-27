using FeedbackForms.Domain.Models;
using FeedbackForms.Infrastructure;

using MediatR;

namespace FeedbackForms.Features.Topics;

public record CreateTopicRequest(string Title, string Body);

public record CreateTopicCommand(CreateTopicRequest Topic)
    : IRequest<Guid>;

public class CreateTopicHandler(AppDbContext appDbContext)
    : IRequestHandler<CreateTopicCommand, Guid>
{
    public async Task<Guid> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var topic = new Topic
        {
            Id = Guid.NewGuid(),
            Title = request.Topic.Title,
            Body = request.Topic.Body,
            CreatedAt = DateTime.UtcNow
        };

        await appDbContext.Topics.AddAsync(topic);
        await appDbContext.SaveChangesAsync();

        return topic.Id;
    }
}