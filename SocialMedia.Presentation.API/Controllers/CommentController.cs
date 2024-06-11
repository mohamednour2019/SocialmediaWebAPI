using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Comment.ResponseDTOs;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces;
using SocialMedia.Presentation.API.Filters;

namespace SocialMedia.Presentation.API.Controllers
{
    [ApiVersion("1.0")]
    public class CommentController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<AddCommentResponseDto>))]
        public async Task<IActionResult> addComment(AddCommentRequestDto requestDto,
            [FromServices] IAddCommentService addCommentService) =>
            await _presenter.Handle(requestDto, addCommentService);

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteCommentResponseDto))]
        public async Task<IActionResult> deleteComment(DeleteCommentRequestDto requestDto,
        [FromServices] IDeleteCommentService deleteCommentService) =>
        await _presenter.Handle(requestDto, deleteCommentService);


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteCommentResponseDto))]
        public async Task<IActionResult> updateComment(UpdateCommentRequestDto requestDto,
        [FromServices] IUpdateCommentService updateCommentService) =>
        await _presenter.Handle(requestDto, updateCommentService);

        [HttpGet("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(ResponseModel<List<GetCommentResponseDto>>))]
        public async Task<IActionResult>getComments(Guid postId
            , [FromServices] IGetCommentsService getCommentsService)
            =>await _presenter.Handle(postId, getCommentsService);


    }
}
