using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces;
using SocialMedia.Presentation.API.ControllerPresenter;

namespace SocialMedia.Presentation.API.Controllers
{
    [ApiVersion(1.0)]
    public class PostController : BaseController
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddPostResponseDto))]
        public async Task<IActionResult> add(AddPostRequestDto requestDto
            , [FromServices] IAddPostService addPostService) =>
            await _presenter.Handle(requestDto, addPostService);


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdatePostResponseDto))]
        public async Task<IActionResult> update(UpdatePostRequestDto requestDto, Guid id
          , [FromServices] IUpdatePostService addPostService) {
            requestDto.PostId = id;
            return await _presenter.Handle(requestDto, addPostService);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeletePostResponseDto))]
        public async Task<IActionResult> delete(Guid id
          , [FromServices] IDeletePostService addPostService) =>
          await _presenter.Handle(new DeletePostRequestDto() { PostId=id}, addPostService);

    }
}
