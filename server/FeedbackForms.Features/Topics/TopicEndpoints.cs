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

        group.MapPost("create", async (CreateTopicRequest request, ISender sender) =>
            await sender.Send(new CreateTopicCommand(request)));

        group.MapGet("get/{id}", async Task<Results<Ok<TopicDto>, NotFound>> (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetTopicQueryById(id));
            return result.IsSuccess
                ? TypedResults.Ok(result.Value)
                : TypedResults.NotFound();
        });

        return group;
    }
}