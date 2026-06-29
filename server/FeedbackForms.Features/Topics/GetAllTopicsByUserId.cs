using ErrorOr;

using FeedbackForms.Features.Shared;
using FeedbackForms.Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace FeedbackForms.Features.Topics;

public record GetAllTopicsByUserIdQuery(Guid UserId)
    : IRequest<ErrorOr<List<TopicDto>>>;

public class GetAllTopicsByUserIdHanler(AppDbContext appDbContext)
    : IRequestHandler<GetAllTopicsByUserIdQuery, ErrorOr<List<TopicDto>>>
{
    public async Task<ErrorOr<List<TopicDto>>> Handle(GetAllTopicsByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await appDbContext.Topics
            .AsNoTracking()
            .Where(t => t.UserId == request.UserId)
            .Select(t => new TopicDto(
                t.Id,
                t.Title,
                t.Body,
                true
            ))
            .ToListAsync();
    }
}