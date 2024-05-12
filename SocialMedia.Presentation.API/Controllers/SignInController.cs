using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;
using SocialMedia.Presentation.API.ControllerPresenter;

namespace SocialMedia.Presentation.API.Controllers
{
    [ApiVersion("1.0")]
    public class SignInController:BaseController
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<SignInResponseDto>))]
        public async Task<IActionResult> signin(SignInRequestDto signInRequestDto
        , [FromServices] ISignInService signInService)
        => await _presenter.Handle(signInRequestDto, signInService);
    }
}
