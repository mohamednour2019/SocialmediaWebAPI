using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Reply.RequestDTOs;
using SocialMedia.Core.DTO_S.Reply.ResponseDTOs;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces.ReplyInterfaces;

namespace SocialMedia.Presentation.API.Controllers
{
    public class ReplyController:BaseController
    {
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK,Type=typeof(ResponseModel<ReplyResponseDto>))]
        //public async Task<IActionResult> addReply(AddReplyRequestDto requestDto, [FromServices]IAddReplyService addReplyService)
        //    =>await _presenter.Handle(requestDto, addReplyService);

        //[HttpGet("replies/{commentId}/user/{userId}")]
        //public async Task<IActionResult> getReplies(Guid commentId, Guid userId
        //    , [FromServices] IGetRepliesService getRepliesService)
        //    => await _presenter.Handle(new GetCommentRepliesRequestDto() 
        //    { UserId = userId, CommentId = commentId}
        //    , getRepliesService);

    }
}
