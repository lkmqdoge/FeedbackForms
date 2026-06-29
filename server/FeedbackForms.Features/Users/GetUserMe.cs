using System.Security.Claims;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FeedbackForms.Features.Users;

public record UserDto(
    string Id,
    string UserName,
    string Email
);

public record GetUserMeQuery() : IRequest<ErrorOr<UserDto>>;

public class GetUserMeHandler(IHttpContextAccessor httpContextAccessor)
    : IRequestHandler<GetUserMeQuery, ErrorOr<UserDto>>
{
    public Task<ErrorOr<UserDto>> Handle(GetUserMeQuery request, CancellationToken cancellationToken)
    {
        var user = httpContextAccessor.HttpContext?.User;

        var id = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var email = user?.FindFirst(ClaimTypes.Email)?.Value;
        var userName = user?.FindFirst(ClaimTypes.Name)?.Value;

        return id is null || email is null || userName is null
            ? Task.FromResult<ErrorOr<UserDto>>(Error.NotFound())
            : Task.FromResult<ErrorOr<UserDto>>(new UserDto(id, userName, email));
    }
}