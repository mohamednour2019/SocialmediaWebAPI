using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SocialMedia.Presentation.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExciptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExciptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";


                if (ex.InnerException is not null)
                {
                    var body = JsonSerializer.Serialize(new
                    {
                        Error = true,
                        ErrorMessage = "Sorry! Something Wrong Occured in Our Servers."
                    });
                    await httpContext.Response.WriteAsync(body);
                }

                if(ex.Message is not null)
                {
                    var body = JsonSerializer.Serialize(new
                    {
                        Error = true,
                        ErrorMessage = ex.Message
                    });
                    await httpContext.Response.WriteAsync(body);
                }
            
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExciptionHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalExciptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExciptionHandlerMiddleware>();
        }
    }
}
