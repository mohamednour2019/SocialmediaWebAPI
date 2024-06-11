using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.OTPInterfaces;

namespace SocialMedia.Presentation.API.Controllers
{
    [ApiVersion(1.0)]
    [AllowAnonymous]
    public class OtpController:BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<VerifyOtpResponseDto>))]
        public async Task<IActionResult> verifyOtp(VerifyOtpRequestDto verifyOtpRequestDto
            , [FromServices] IVerifyOtpService verifyOtpService) =>
            await _presenter.Handle(verifyOtpRequestDto, verifyOtpService);


        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<UpdateOtpResponseDto>))]
        public async Task<IActionResult> updateOtp(UpdateOtpRequestDto updateOtpRequestDto,
            [FromServices]IUpdateOtpService updateOtpService)
            =>await _presenter.Handle(updateOtpRequestDto,updateOtpService);
    }
}
