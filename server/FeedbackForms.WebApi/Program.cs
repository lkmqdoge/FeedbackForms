using FeedbackForms.Infrastructure;
using FeedbackForms.WebApi.Extenisons;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureAppBuilder();

var app = builder.Build();
app.ConfigureApp();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        dbContext.Database.Migrate();
        Console.WriteLine("Migrations applied");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error while trying to apply migrations: {ex.Message}");
        throw;
    }
}

app.Run();
app.Run();