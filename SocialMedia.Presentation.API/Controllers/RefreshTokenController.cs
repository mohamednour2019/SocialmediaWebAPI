using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Token.RequestDTOs;
using SocialMedia.Core.DTO_S.Token.ResponseDTOs;
using SocialMedia.Core.ServicesInterfaces.TokenInterfaces;

namespace SocialMedia.Presentation.API.Controllers
{
    [AllowAnonymous]
    public class RefreshTokenController:BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(ResponseModel<RefreshTokenResponseDto>))]
        public async Task<IActionResult> refreshToken(RefreshTokenRequestDto requestDto
            , [FromServices]IRefreshTokenService refreshTokenService)=>
            await _presenter.Handle(requestDto,refreshTokenService);
    }
}
