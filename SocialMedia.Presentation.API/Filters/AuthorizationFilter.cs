using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace SocialMedia.Presentation.API.Filters
{
    public class AuthorizationFilter : Attribute, IAsyncAuthorizationFilter
    {
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Cookies.ContainsKey(".AspNetCore.Identity.Application"))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Content = JsonSerializer.Serialize(new { Error = true, ErrorMessage = "You have To Login First!" })
                };
            }

            return Task.CompletedTask;
        }
    }
}
