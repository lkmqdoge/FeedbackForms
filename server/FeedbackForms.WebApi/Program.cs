using FeedbackForms.WebApi.Extenisons;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureAppBuilder();

var app = builder.Build();
app.ConfigureApp();

app.Run();