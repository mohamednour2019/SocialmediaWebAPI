using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using SocialMedia.Presentation.API.Filters;
using System.Security.Policy;

namespace SocialMedia.Presentation.API.Controllers
{
    [ApiVersion(1.0)]
    //[AuthorizationFilter]
    public class FriendsController:BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<AddFriendResponseDto>))]
        public async Task<IActionResult> addFriend(AddFriendRequestDto requestDto
            , [FromServices]IAddFriendService addFriendService)=>
            await _presenter.Handle(requestDto, addFriendService);


        [HttpGet("requests/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<List<GetFriendGenericResposneDto>>))]
        public async Task<IActionResult> getFriendRequests(Guid id, [BindNever] GetFriendGenericRequestDto requestDto
            , [FromServices] IGetFriendsGenericService getFriendRequestsService) =>
            await _presenter.Handle(new GetFriendGenericRequestDto() {UserId= id, Status=FriendshipStatus.FriendRequest,Message="requests" }, getFriendRequestsService);


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<List<GetFriendGenericResposneDto>>))]
        public async Task<IActionResult> getFriends(Guid id, [BindNever]GetFriendGenericRequestDto requestDto
            , [FromServices] IGetFriendsGenericService getFriendRequestsService) =>
            await _presenter.Handle(new GetFriendGenericRequestDto() { UserId = id, Status = FriendshipStatus.Friends, Message = "friends" }, getFriendRequestsService);


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<AcceptFirendRequestReaponseDto>))]
        public async Task<IActionResult> acceptFriend(AcceptFriendRequestRequestDto requestDto,
            [FromServices]IAcceptFriendRequestService acceptFriendRequestService)=>
            await _presenter.Handle(requestDto, acceptFriendRequestService);


        [HttpDelete("unfriend")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<DeleteFriendshipResponseDto>))]
        public async Task<IActionResult> unfirend(DeleteFriendshipRequestDto requestDto,
        [FromServices] IUnfriendService unfriendService) =>
        await _presenter.Handle(requestDto, unfriendService);


        [HttpDelete("reject")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<DeleteFriendshipResponseDto>))]
        public async Task<IActionResult> rejectRequest(DeleteFriendshipRequestDto requestDto,
        [FromServices] IRejectFriendRequestService rejectFriendRequestService) =>
        await _presenter.Handle(requestDto, rejectFriendRequestService);

    }
}
