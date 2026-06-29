using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using FeedbackForms.Domain;
using FeedbackForms.Domain.Abstractions;
using FeedbackForms.Domain.Models;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FeedbackForms.Infrastructure.Auth;

public class JwtService(IOptions<AuthSettings> options) : IJwtService
{
    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.UserName),
            new (ClaimTypes.Email, user.Email),
        };

        var jwtToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.Add(options.Value.Expires),
            signingCredentials:
            new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey)),
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}

