using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace FeedbackForms.Features.Users;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder UseUserEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("/users");

        group.MapPost("/register", async (RegisterUserRequest request, ISender sender) =>
            await sender.Send(new RegisterUserCommand(request)));

        group.MapPost("/login", async (LoginUserRequest request, ISender sender) => {
            var result = await sender.Send(new LoginUserCommand(request));
            return result.Value;
        });

        group.MapGet("/me", async (ISender sender) => {
            var result = await sender.Send(new GetUserMeQuery());
            return result.Value;
        }).RequireAuthorization();

        return group;
    }
}