using SocialMedia.Core.Services.HubServices;
using SocialMedia.Presentation.API.Middlewares;

namespace SocialMedia.Presentation.API.Initializer
{
    public static class ApplicationInitializer
    {
        public static WebApplication Initialize(this WebApplication app)
        {
            app.MapHub<MessengerHubService>("/messenger");
            app.UseGlobalExciptionHandler();
            app.UseHsts();
            app.UseRouting();
            app.UseCors(options =>
            {
                options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
            app.MapControllers();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Social Media API v1");
            });
            return app;
        }
    }
}
