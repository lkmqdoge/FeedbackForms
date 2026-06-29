using ErrorOr;

using FeedbackForms.Features.Shared;
using FeedbackForms.Infrastructure;
using MediatR;

using Microsoft.EntityFrameworkCore;

namespace FeedbackForms.Features.Topics;

public record GetTopicByIdRequest(Guid TopicId, Guid? UserId = null);
public record GetTopicByIdQuery(GetTopicByIdRequest Request)
    : IRequest<ErrorOr<TopicDto>>;

public class GetTopicByIdHandler(AppDbContext appDbContext)
    : IRequestHandler<GetTopicByIdQuery, ErrorOr<TopicDto>>
{
    public async Task<ErrorOr<TopicDto>> Handle(GetTopicByIdQuery request, CancellationToken cancellationToken)
    {
        var topic = await appDbContext.Topics
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == request.Request.TopicId, cancellationToken);

        if (topic is null)
        {
            return Error.NotFound();
        }

        var isOwner = (request.Request.UserId is not null) && topic.UserId == request.Request.UserId;

        return new TopicDto(
                topic.Id,
                topic.Title,
                topic.Body,
                isOwner);
    }
}