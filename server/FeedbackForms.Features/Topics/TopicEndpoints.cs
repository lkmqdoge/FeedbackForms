using System.Security.Claims;

using FeedbackForms.Features.Shared;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace FeedbackForms.Features.Topics;

public static class TopicEndpoints
{
    public static IEndpointRouteBuilder UseTopicEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("/topics");

        group.MapPost("/", async Task<Results<Ok<Guid>, NotFound>> (CreateTopicRequest request, ISender sender) => {
            var result = await sender.Send(new CreateTopicCommand(request));
            return result.IsSuccess
                ? TypedResults.Ok(result.Value)
                : TypedResults.NotFound();
        });

        group.MapGet("/{id}", async Task<Results<Ok<TopicDto>, NotFound>> (
            Guid id,
            ClaimsPrincipal user,
            ISender sender
            ) =>
        {
            Guid? userId = null;

            if (user.Identity?.IsAuthenticated == true && Guid.TryParse(user?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var resultUserId))
            {
                userId = resultUserId;
            }

            var result = await sender.Send(new GetTopicByIdQuery(new (id, userId)));
            return result.IsSuccess
                ? TypedResults.Ok(result.Value)
                : TypedResults.NotFound();
        });

        group.MapGet("/byUser/{id}", async Task<Results<Ok<List<TopicDto>>, NotFound>> (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetAllTopicsByUserIdQuery(id));
            return result.IsSuccess
                ? TypedResults.Ok(result.Value)
                : TypedResults.NotFound();
        })
        .RequireAuthorization();

        return group;
    }
}