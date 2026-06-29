using ErrorOr;

using FeedbackForms.Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace FeedbackForms.Features.Answers;

public record AnswerDto(
    string UserName,
    string Email,
    string Text
);
public record GetAllAnswersByTopicIdQuery(Guid TopicId)
    : IRequest<ErrorOr<List<AnswerDto>>>;

public class GetAllTopicsByUserId(AppDbContext appDbContext)
    : IRequestHandler<GetAllAnswersByTopicIdQuery, ErrorOr<List<AnswerDto>>>
{
    public async Task<ErrorOr<List<AnswerDto>>> Handle(GetAllAnswersByTopicIdQuery request, CancellationToken cancellationToken)
    {
        var isTopicExists = await appDbContext.Topics
            .AsNoTracking()
            .AnyAsync(t => t.Id == request.TopicId);

        return isTopicExists
            ? await appDbContext.Answers
                .Where(a => a.TopicId == request.TopicId)
                .Select(a => new AnswerDto(a.UserName, a.Email, a.Text))
                .ToListAsync()
            : Error.NotFound();
    }
}

