using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Like.RequestDTOs;
using SocialMedia.Core.DTO_S.Like.ResponseDTOs;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.LikeInterfaces;


namespace SocialMedia.Presentation.API.Controllers
{
    [ApiVersion("1.0")]
    public class LikeController:BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<LikeResponseDto>))]
        public async Task<IActionResult>addLike(AddLikeRequestDto requestDto,
            [FromServices]IAddLikeService service)=>
            await _presenter.Handle(requestDto, service);


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<LikeResponseDto>))]
        public async Task<IActionResult> removeLike(UnlikeRequestDto requestDto,
            [FromServices] IUnlikeService service) =>
            await _presenter.Handle(requestDto, service);

        [HttpGet("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<List<LikeResponseDto>>))]
        public async Task<IActionResult> getLikes(Guid postId,[FromQuery]int pageNumber, [FromServices] IGetLikesService getLikesService)
            => await _presenter.Handle(new GetLikesRequestDto() { PostId=postId,PageNumber=pageNumber}, getLikesService);    
    }
}
