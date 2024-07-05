using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Chat.RequestDTOs;
using SocialMedia.Core.DTO_S.Chat.ResponseDTOs;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.ServicesInterfaces.MessegesInterfaces;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;

namespace SocialMedia.Presentation.API.Controllers
{
    public class UserController:BaseController
    {
        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<string>))]
        public async Task<IActionResult> deleteUserConnection(Guid userId
            , [FromServices] IDeleteUserConnectionService toggleUserStatusService)
            => await _presenter.Handle(userId, toggleUserStatusService);

        [HttpPost("picture")]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(ResponseModel<string>))]
        public async Task<IActionResult> addProfilePicture([FromForm]AddUserImageRequestDto requestDto,
            [FromServices] IAddProfilePictureService addProfilePictureService)
            => await  _presenter.Handle(requestDto, addProfilePictureService);

        [HttpPost("cover")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<string>))]
        public async Task<IActionResult> addCoverPicture([FromForm] AddUserImageRequestDto requestDto,
        [FromServices] IAddCoverPictureService addCoverPictureService)
        => await _presenter.Handle(requestDto, addCoverPictureService);

        [HttpGet("chats/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<List<GetUserChatResponseDto>>))]
        public async Task<IActionResult> getUserChats(Guid userId,[FromQuery]int pageNumber,[FromServices] IGetUserChatsService getUserChatsService)
            =>await _presenter.Handle(new GetUserChatRequestDto() { UserId=userId,PageNumber=pageNumber}, getUserChatsService);   
    }
}
