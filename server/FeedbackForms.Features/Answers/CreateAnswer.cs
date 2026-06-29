using ErrorOr;

using FeedbackForms.Domain.Models;
using FeedbackForms.Infrastructure;
using FeedbackForms.Infrastructure.Captcha;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FeedbackForms.Features.Answers;

public record CreateAnswerRequest(
    Guid TopicId,
    string Email,
    string UserName,
    string Text,
    string CaptchaToken
);

public record CreateAnswerCommand(CreateAnswerRequest Request, string? RemoteIp = null)
    : IRequest<ErrorOr<Guid>>;

public class CreateAnswerHanler(AppDbContext appDbContext,
        ILogger logger, TurnstileService turnstileService)
    : IRequestHandler<CreateAnswerCommand, ErrorOr<Guid>>
{
    public async Task<ErrorOr<Guid>> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
    {
        var captchaValid = await turnstileService.ValidateTokenAsync(
                request.Request.CaptchaToken,
                request.RemoteIp);

        if (!captchaValid)
        {
            logger.LogInformation("Captcha Invalid");
            return Error.Validation(
                    code: "Captcha.Invalid",
                    description: "Captcha validation failed.");
        }

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
            CreatedAt = DateTime.UtcNow
        };

        await appDbContext.Answers.AddAsync(answer, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return answer.Id;
    }
}