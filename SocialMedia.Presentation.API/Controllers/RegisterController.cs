using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.OTPInterfaces;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;
namespace SocialMedia.Presentation.API.Controllers
{
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class RegisterController:BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<RegisterResponseDto>))]
        public async Task<IActionResult> register(RegisterRequestDto registerRequestDto
        , [FromServices] IRegisterService registerService) =>
        await _presenter.Handle(registerRequestDto, registerService);

    }
}
