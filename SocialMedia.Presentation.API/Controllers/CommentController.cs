using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Comment.RequestDTOs;
using SocialMedia.Core.DTO_S.Comment.ResponseDTOs;
using SocialMedia.Core.DTO_S.Reply.RequestDTOs;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces.ReplyInterfaces;
using SocialMedia.Presentation.API.Filters;

namespace SocialMedia.Presentation.API.Controllers
{
    [ApiVersion("1.0")]
    public class CommentController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<CommentResponseDto>))]
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

        [HttpGet("{postId}/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<List<GetCommentResponseDto>>))]
        public async Task<IActionResult> getComments(Guid postId, Guid userId, [FromQuery] int pageNumber
            , [FromServices] IGetCommentsService getCommentsService)
            => await _presenter.Handle(new GetCommentsRequestDto() { PostId = postId, UserId = userId, PageNumber = pageNumber }
            , getCommentsService);


        [HttpPost("reply")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<GetCommentResponseDto>))]
        public async Task<IActionResult> addReply(AddReplyRequestDto requestDto, [FromServices] IAddReplyService addReplyService)
            => await _presenter.Handle(requestDto, addReplyService);



        [HttpGet("replies/{CommentParentId}/user/{userId}")]
        public async Task<IActionResult> getReplies(Guid commentParentId, Guid userId
            , [FromServices] IGetRepliesService getRepliesService)
            => await _presenter.Handle(new GetCommentRepliesRequestDto()
            { UserId = userId, CommentParentId = commentParentId }
            , getRepliesService);

    }
}
