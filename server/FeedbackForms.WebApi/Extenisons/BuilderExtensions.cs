using FeedbackForms.Features.Forms;
using FeedbackForms.Infrastructure;

using Microsoft.OpenApi;

namespace FeedbackForms.WebApi.Extenisons;

public static class BuilderExtensions
{
    public static void ConfigureAppBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.AddDataAccess(builder.Configuration);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "FeedbackForms",
            Version = "v1",
            Description = "FeedbackForms api",
            Contact = new OpenApiContact
            {
                Name = "lkmqdoge",
                Email = "leere0@proton.me"
            }
        }));
        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(FormsEndpoints).Assembly));
    }
}
