using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace FeedbackForms.Features.Topics;

public static class TopicEndpoints
{
    public static IEndpointRouteBuilder UseTopicEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("/topics");

        group.MapPost("create", async (CreateTopicRequest request, ISender sender) => 
        {
            return await sender.Send(new CreateTopicCommand(request));
        });

        return group;
    }
}
