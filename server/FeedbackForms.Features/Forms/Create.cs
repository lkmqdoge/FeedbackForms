using FeedbackForms.Domain.Models;
using FeedbackForms.Infrastructure;

using MediatR;

namespace FeedbackForms.Features.Forms;

public record CreateFormCommand(CreateFormRequest Request)
    : IRequest<Guid>;

public record CreateFormRequest
{
    public string Title { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class CreateProductHandler(
    AppDbContext appDbContext)
    : IRequestHandler<CreateFormCommand, Guid>
{
    public async Task<Guid> Handle(CreateFormCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}