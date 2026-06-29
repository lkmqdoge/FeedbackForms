using ErrorOr;

using FeedbackForms.Domain.Models;
using FeedbackForms.Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace FeedbackForms.Features.Topics;

public record CreateTopicRequest(string Title, string Body, Guid UserId);

public record CreateTopicCommand(CreateTopicRequest Topic)
    : IRequest<ErrorOr<Guid>>;

public class CreateTopicHandler(AppDbContext appDbContext)
    : IRequestHandler<CreateTopicCommand, ErrorOr<Guid>>
{
    public async Task<ErrorOr<Guid>> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var isUserExist = await appDbContext.Users
            .AsNoTracking()
            .AnyAsync(u => u.Id == request.Topic.UserId);

        if (!isUserExist)
        {
            return Error.NotFound();
        }

        var topic = new Topic
        {
            Id = Guid.NewGuid(),
            Title = request.Topic.Title,
            Body = request.Topic.Body,
            CreatedAt = DateTime.UtcNow,
            UserId = request.Topic.UserId
        };

        await appDbContext.Topics.AddAsync(topic);
        await appDbContext.SaveChangesAsync();

        return topic.Id;
    }
}