using FeedbackForms.Features.Answers;
using FeedbackForms.Features.Topics;
using FeedbackForms.Features.Users;

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
        var apiGroup = app.MapGroup("/api");

        apiGroup.MapGet("/hello", async () => "hello");
        apiGroup.UseTopicEndpoints();
        apiGroup.UseAnswerEndpoints();
        apiGroup.UseUserEndpoints();

        app.UseAuthentication();
        app.UseAuthorization();
    }
}