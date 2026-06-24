using Microsoft.AspNetCore.Routing;

namespace FeedbackForms.Domain.Abstractions;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder builder);
}
