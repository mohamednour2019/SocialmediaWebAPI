using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.LikeInterfaces;
using SocialMedia.Presentation.API.Filters;
using System.Net;

namespace SocialMedia.Presentation.API.Controllers
{
    [ApiVersion("1.0")]
    public class LikeController:BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<AddLikeResponseDto>))]
        public async Task<IActionResult>addLike(AddLikeRequestDto requestDto,
            [FromServices]IAddLikeService service)=>
            await _presenter.Handle(requestDto, service);


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<AddLikeResponseDto>))]
        public async Task<IActionResult> removeLike(UnlikeRequestDto requestDto,
            [FromServices] IUnlikeService service) =>
            await _presenter.Handle(requestDto, service);
    }
}
