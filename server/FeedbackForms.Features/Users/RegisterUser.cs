using FeedbackForms.Domain.Models;
using FeedbackForms.Infrastructure;

using MediatR;

using Microsoft.AspNetCore.Identity;

namespace FeedbackForms.Features.Users;

public record RegisterUserRequest(
    string UserName,
    string Email,
    string Password
);

public record RegisterUserCommand(RegisterUserRequest User)
    : IRequest<Guid>;

public class RegisterUserHanlder(AppDbContext appDbContext)
    : IRequestHandler<RegisterUserCommand, Guid>
{
    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = request.User.UserName,
            Email = request.User.Email,
            CreatedAt = DateTime.UtcNow
        };
        user.HashedPassword = new PasswordHasher<User>().HashPassword(user, request.User.Password);

        await appDbContext.Users.AddAsync(user);
        await appDbContext.SaveChangesAsync();

        return user.Id;
    }
}