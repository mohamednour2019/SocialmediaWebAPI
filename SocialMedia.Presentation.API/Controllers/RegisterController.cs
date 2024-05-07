using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.OTPInterfaces;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;
using SocialMedia.Presentation.API.ControllerPresenter;

namespace SocialMedia.Presentation.API.Controllers
{
    [ApiVersion("1.0")]
    public class RegisterController:BaseController
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterResponseDto))]
        public async Task<IActionResult> register(RegisterRequestDto registerRequestDto
        , [FromServices] IRegisterService registerService) =>
        await _presenter.Handle(registerRequestDto, registerService);

        [HttpPost("verify")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterResponseDto))]
        public async Task<IActionResult> verifyOtp(VerifyOtpRequestDto verifyOtpRequestDto
            ,[FromServices]IVerifyOtpService verifyOtpService)=>
            await _presenter.Handle(verifyOtpRequestDto,verifyOtpService);
    }
}
