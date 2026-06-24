using FeedbackForms.Features.Answers;
using FeedbackForms.Features.Topics;

namespace FeedbackForms.WebApi.Extenisons;

public static class AppExtensions
{
    public static void ConfigureApp(this WebApplication app)
    {
        app.UseHttpsRedirection();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Product service v1");
                options.RoutePrefix = string.Empty;
            });
        }

        app.UseTopicEndpoints();
        app.UseAnswerEndpoints();
    }
}