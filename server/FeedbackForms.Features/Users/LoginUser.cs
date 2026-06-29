using ErrorOr;

using FeedbackForms.Domain.Abstractions;
using FeedbackForms.Domain.Models;
using FeedbackForms.Infrastructure;

using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FeedbackForms.Features.Users;

public record LoginUserRequest(
    string Email,
    string Password
);

public record LoginUserCommand(LoginUserRequest User)
    : IRequest<ErrorOr<string>>;

public class LoginUserHandler(AppDbContext appDbContext, IJwtService jwtService)
    : IRequestHandler<LoginUserCommand, ErrorOr<string>>
{
    public async Task<ErrorOr<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await appDbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == request.User.Email);

        if (user is null)
        {
            return Error.NotFound();
        }

        var result = new PasswordHasher<User>().VerifyHashedPassword(user, user.HashedPassword, request.User.Password);
        return result == PasswordVerificationResult.Success
            ? jwtService.GenerateToken(user)
            : Error.Failure();
    }
}
