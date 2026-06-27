using FeedbackForms.Features.Answers;
using FeedbackForms.Features.Topics;

namespace FeedbackForms.WebApi.Extenisons;

public static class AppExtensions
{
    public static void ConfigureApp(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.MapGet("/", async () => "Hello!");

        var apiGroup = app.MapGroup("/api");
        apiGroup.UseTopicEndpoints();
        apiGroup.UseAnswerEndpoints();
    }
}