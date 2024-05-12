using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SocialMedia.Core.Domain.Entities;
using System.Text.Json;

namespace SocialMedia.Presentation.API.Filters
{
    public class RequestDtoValidationActionFilter
    {
        public static IActionResult OnActionExecuting(ActionContext context)
        {
            if (!context.ModelState.IsValid)
            {
                List<string>errorMessages= context.ModelState.Values.SelectMany(x=>x.Errors).Select(x=>x.ErrorMessage).ToList();
                var body = JsonSerializer.Serialize(new ResponseModel<object>
                {
                    Success = false,
                    Message = errorMessages,
                    Data = null
                });
                return new ContentResult()
                {
                    Content = body,
                    StatusCode = StatusCodes.Status400BadRequest // Set the status code
                };
            }
            else return null;
        }
    }
}
