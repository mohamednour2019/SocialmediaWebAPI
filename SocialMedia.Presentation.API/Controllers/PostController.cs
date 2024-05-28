using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces;
using SocialMedia.Presentation.API.ControllerPresenter;
using SocialMedia.Presentation.API.Filters;

namespace SocialMedia.Presentation.API.Controllers
{
    [ApiVersion(1.0)]
    public class PostController : BaseController
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddPostResponseDto))]
        public async Task<IActionResult> add([FromForm]AddPostRequestDto requestDto
            , [FromServices] IAddPostService addPostService) =>
            await _presenter.Handle(requestDto, addPostService);


        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<UpdatePostResponseDto>))]
        public async Task<IActionResult> update(UpdatePostRequestDto requestDto, Guid id
          , [FromServices] IUpdatePostService addPostService)=>
            await _presenter.Handle(new UpdatePostRequestDto() 
            { PostId = id,Content = requestDto.Content}, addPostService);



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<DeletePostResponseDto>))]
        public async Task<IActionResult> delete(Guid id
          , [FromServices] IDeletePostService addPostService) =>
          await _presenter.Handle(new DeletePostRequestDto() { PostId=id}, addPostService);


        [HttpGet("profile/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<List<GetUserPostsResponseDto>>))]

        public async Task<IActionResult> getUserPosts(Guid userId
            , [FromServices]IGetUserPostsService getUserPostsService)=>
            await _presenter.Handle(new GetUserPostsRequestDto() { UserId=userId},getUserPostsService);

        [HttpGet("newsfeed/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<List<GetNewsFeedPostsResponseDto>>))]
        public async Task<IActionResult> getNewsFeedPosts(Guid userId
            , [FromServices]IGetNewsFeedPostsService getNewsFeedPostsService)=>
            await _presenter.Handle(new GetNewsFeedPostsRequestDto() { UserId =userId},getNewsFeedPostsService);

        [HttpGet("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<GetUserPostsResponseDto>))]
        public async Task<IActionResult> getPost(Guid postId, [FromServices] IGetPostService getPostService)
            => await _presenter.Handle(postId, getPostService);

    }
}
