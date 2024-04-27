using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using System.Security.Policy;

namespace SocialMedia.Presentation.API.Controllers
{
    [ApiVersion(1.0)]
    public class FriendController:BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddFriendResponseDto))]
        public async Task<IActionResult> addFriend(AddFriendRequestDto requestDto
            , [FromServices]IAddFriendService addFriendService)=>
            await _presenter.Handle(requestDto, addFriendService);


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetFriendRequestsResponseDto))]
        public async Task<IActionResult> getFriendRequests(Guid id
            , [FromServices] IGetFriendRequestsService getFriendRequestsService) =>
            await _presenter.Handle(id, getFriendRequestsService);


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AcceptFirendRequestReaponseDto))]
        public async Task<IActionResult> acceptFriend(AcceptFriendRequestRequestDto requestDto,
            [FromServices]IAcceptFriendRequestService acceptFriendRequestService)=>
            await _presenter.Handle(requestDto, acceptFriendRequestService);

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RejectFriendRequestResponseDto))]
        public async Task<IActionResult> rejectFriend(RejectFriendRequestRequestDto requestDto,
        [FromServices] IRejectFriendRequestService rejectFriendRequestService) =>
        await _presenter.Handle(requestDto, rejectFriendRequestService);

    }
}
