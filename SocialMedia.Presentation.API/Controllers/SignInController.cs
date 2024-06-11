using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;

namespace SocialMedia.Presentation.API.Controllers
{
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class SignInController:BaseController
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<SignInResponseDto>))]
        public async Task<IActionResult> signin(SignInRequestDto signInRequestDto
        , [FromServices] ISignInService signInService)
        => await _presenter.Handle(signInRequestDto, signInService);
    }
}
