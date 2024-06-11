using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.SharedKernel.CustomExceptions;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SocialMedia.Presentation.API.Middlewares
{
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
                var response = new ResponseModel<object>
                {
                    Success = false,
                    Data = null
                };
                httpContext.Response.ContentType = "application/json";

                if (ex is ViolenceValidationException)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message=new List<string>() {ex.Message};
                }
                else if(ex is SecurityTokenExpiredException)
                {
                    httpContext.Response.StatusCode=(int)HttpStatusCode.Unauthorized;
                    response.Message = new List<string>() { ex.Message };
                }
                else
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Message = new List<string>() {"Sorry, Something Went Wrong Please Try Again Later."};
                }
                string responseBody = JsonSerializer.Serialize(response);
                await httpContext.Response.WriteAsync(responseBody);


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
