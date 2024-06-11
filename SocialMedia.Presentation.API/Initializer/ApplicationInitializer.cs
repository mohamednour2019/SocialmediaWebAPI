using SocialMedia.Core.Services.HubServices;
using SocialMedia.Presentation.API.Middlewares;

namespace SocialMedia.Presentation.API.Initializer
{
    public static class ApplicationInitializer
    {
        public static WebApplication Initialize(this WebApplication app)
        {
            app.UseGlobalExciptionHandler();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(options =>
            {
                options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.MapHub<MessengerHubService>("/messenger");
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Social Media API v1");
            });
            return app;
        }
    }
}
