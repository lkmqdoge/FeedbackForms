using FeedbackForms.Domain.Abstractions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FeedbackForms.Features.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, AppDomain domain)
    {
        var endpoints = domain.GetAssemblies() 
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type is { IsAbstract: false, IsInterface: false } && type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type));
        
        services.TryAddEnumerable(endpoints);

        return services;
    }
}

