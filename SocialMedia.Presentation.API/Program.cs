using SocialMedia.Presentation.API.Initializer;
using SocialMedia.Presentation.API.ServicesConfigurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();
app.Initialize();
app.Run();
