using ErrorOr;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace FeedbackForms.Features.Answers;

public static class AnswerEnpoints
{
    public static IEndpointRouteBuilder UseAnswerEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("/answers");

        group.MapPost("/", async Task<Results<Ok<Guid>, NotFound>> (CreateAnswerRequest request, ISender sender, HttpContext context) => {
            var remoteIp = context.Connection.LocalIpAddress?.ToString();
            var result = await sender.Send(new CreateAnswerCommand(request, remoteIp));
            return result.IsSuccess
                ? TypedResults.Ok(result.Value)
                : TypedResults.NotFound();
        });

        group.MapGet("/byTopic/{id}", async Task<Results<Ok<List<AnswerDto>>, ValidationProblem>> (Guid id, ISender sender) => {
            var result = await sender.Send(new GetAllAnswersByTopicIdQuery(id));

            return result.IsSuccess
                ? TypedResults.Ok(result.Value)
                : TypedResults.ValidationProblem(result
                        .Errors.GroupBy(e => e.Code)
                        .ToDictionary(g =>g.Key, g => g.Select(e=>e.Description).ToArray()));

        }).RequireAuthorization();

        return group;
    }
}