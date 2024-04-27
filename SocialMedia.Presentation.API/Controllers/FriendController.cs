using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using System.Security.Policy;

namespace SocialMedia.Presentation.API.Controllers
{
    [ApiVersion(1.0)]
    public class FriendController:BaseController
    {
        [HttpPost]
        public async Task<IActionResult> addFriend(AddFriendRequestDto requestDto
            , [FromServices]IAddFriendService addFriendService)=>
            await _presenter.Handle(requestDto, addFriendService);


        [HttpGet("{id}")]
        public async Task<IActionResult> getFriendRequests(Guid id
            , [FromServices] IGetFriendRequestsService getFriendRequestsService) =>
            await _presenter.Handle(id, getFriendRequestsService);


        [HttpPut]
        public async Task<IActionResult> acceptFriend(AcceptFriendRequestRequestDto requestDto,
            [FromServices]IAcceptFriendRequestService acceptFriendRequestService)=>
            await _presenter.Handle(requestDto, acceptFriendRequestService);

        [HttpDelete]
        public async Task<IActionResult> rejectFriend(RejectFriendRequestRequestDto requestDto,
        [FromServices] IRejectFriendRequestService rejectFriendRequestService) =>
        await _presenter.Handle(requestDto, rejectFriendRequestService);

    }
}
