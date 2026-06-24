using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FeedbackForms.Features.Answers;

public static class AnswerEnpoints
{
    public static IEndpointRouteBuilder UseAnswerEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("/answers");
        group.MapPost("/create", async Task<IResult> (CreateAnswerRequest request, ISender sender) => {
            var result = await sender.Send(new CreateAnswerCommand(request));
            return result.IsSuccess
                ? TypedResults.Created(result.Value.ToString())
                : TypedResults.NotFound();
        });

        return group;
    }
}
