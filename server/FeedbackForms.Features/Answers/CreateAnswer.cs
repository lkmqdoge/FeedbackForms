using ErrorOr;

using FeedbackForms.Domain.Models;
using FeedbackForms.Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace FeedbackForms.Features.Answers;

public record CreateAnswerRequest(
    Guid TopicId,
    string Email,
    string UserName,
    string Text
);

public record CreateAnswerCommand(CreateAnswerRequest Request)
    : IRequest<ErrorOr<Guid>>;

public class CreateAnswerHanler(AppDbContext appDbContext)
    : IRequestHandler<CreateAnswerCommand, ErrorOr<Guid>>
{
    public async Task<ErrorOr<Guid>> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
    {
        var isTopicExists = await appDbContext.Topics
            .AsNoTracking()
            .AnyAsync(t => t.Id == request.Request.TopicId);

        if (!isTopicExists)
            return Error.NotFound();

        var answer = new Answer{
            Id = Guid.NewGuid(),
            UserName = request.Request.UserName,
            Email =  request.Request.Email,
            TopicId = request.Request.TopicId,
            Text = request.Request.Text,
        };

        await appDbContext.Answers.AddAsync(answer);
        await appDbContext.SaveChangesAsync();

        return answer.Id;
    }
}