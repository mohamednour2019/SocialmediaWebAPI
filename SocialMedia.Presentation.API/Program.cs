
using SocialMedia.Presentation.API.Middlewares;
using SocialMedia.Presentation.API.ServicesConfigurations;


var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseGlobalExciptionHandler();
app.UseHsts();
app.UseRouting();
app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});
app.MapControllers();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Social Media API v1");
});

app.Run();


