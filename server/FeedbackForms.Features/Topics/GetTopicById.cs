using ErrorOr;

using FeedbackForms.Infrastructure;
using MediatR;

using Microsoft.EntityFrameworkCore;

namespace FeedbackForms.Features.Topics;

public record TopicDto(
    Guid Guid,
    string Title,
    string Body
);
public record GetTopicQueryById(Guid Id)
    : IRequest<ErrorOr<TopicDto>>;

public class GetTopicHandler(AppDbContext appDbContext)
    : IRequestHandler<GetTopicQueryById, ErrorOr<TopicDto>>
{
    public async Task<ErrorOr<TopicDto>> Handle(GetTopicQueryById request, CancellationToken cancellationToken)
    {
        var topic = await appDbContext.Topics
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == request.Id);

        return topic is null
            ? Error.NotFound()
            : new TopicDto(
                topic.Id,
                topic.Title,
                topic.Body);
    }
}
