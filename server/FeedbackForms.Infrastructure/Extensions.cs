using System.Text;

using FeedbackForms.Domain;
using FeedbackForms.Domain.Abstractions;
using FeedbackForms.Infrastructure.Auth;
using FeedbackForms.Infrastructure.Captcha;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FeedbackForms.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opts =>
            opts.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention());

        var authSettings = configuration.GetSection(nameof(AuthSettings))
            .Get<AuthSettings>()
            ?? throw new InvalidOperationException($"Required configuration section \"{nameof(AuthSettings)}\" is missing");

        services
            .AddScoped<IJwtService, JwtService>()
            .Configure<AuthSettings>(configuration.GetSection("AuthSettings"))
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(authSettings.SecretKey))
                };

                o.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        if (context.Request.Cookies.TryGetValue("access_token", out var token))
                            context.Token = token;

                        return Task.CompletedTask;
                    }
                };
            });

        services
            .Configure<TurnstileSettings>(configuration.GetSection("TurnstileSettings"))
            .AddHttpClient<TurnstileService>();


        return services;
    }
}
