using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace FeedbackForms.Features.Users;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder UseUserEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("/users");

        group.MapPost("/register", async (RegisterUserRequest request, ISender sender) =>
            await sender.Send(new RegisterUserCommand(request)));

        group.MapPost("/login", async Task<Results<Ok<string>, UnauthorizedHttpResult>> (LoginUserRequest request, ISender sender) => {
            var result = await sender.Send(new LoginUserCommand(request));
            return result.IsSuccess
                ? TypedResults.Ok(result.Value)
                : TypedResults.Unauthorized();
        });

        group.MapGet("/me", async Task<Results<Ok<UserDto>, UnauthorizedHttpResult>> (ISender sender) => {
            var result = await sender.Send(new GetUserMeQuery());
            return result.IsSuccess
                ? TypedResults.Ok(result.Value)
                : TypedResults.Unauthorized();
        }).RequireAuthorization();

        return group;
    }
}