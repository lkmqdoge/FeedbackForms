using FeedbackForms.Domain.Abstractions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FeedbackForms.Features.Extensions;

public static class AppExtensions
{
    public static WebApplication UseEndpoints(
        this WebApplication app,
        IEndpointRouteBuilder? routeGroupBuilder = null)
    {
        var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();
        var builder = routeGroupBuilder ?? app;

        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoint(builder);
        }

        return app;
    }
}

