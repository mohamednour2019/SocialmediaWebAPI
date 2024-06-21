using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using SocialMedia.Core.DTO_S.Friendship.ResponseDTOs;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;


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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<List<GetFriendRequestsResponseDto>>))]
        public async Task<IActionResult> getFriendRequests(Guid id
            , [FromServices] IGetFriendRequests getFriendRequestsService) =>
            await _presenter.Handle(id, getFriendRequestsService);


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<List<GetFriendGenericResposneDto>>))]
        public async Task<IActionResult> getFriends(Guid id
            , [FromServices] IGetFirendsService getFriendRequestsService) =>
            await _presenter.Handle(id, getFriendRequestsService);


        [HttpPatch]
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


        [HttpGet("user/{requestedUserId}/status/{currentUserId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<GetUserResponseDto>))]
        public async Task<IActionResult> getUser(Guid requestedUserId, Guid currentUserId,
            [FromServices] IGetUserService getUserService) =>
            await _presenter.Handle(new GetUserRequestDto() 
            { CurrentUserId = currentUserId, RequestedUserId = requestedUserId }
            , getUserService);


        [HttpGet("suggestions/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(ResponseModel<List<GetFriendsSuggestionsResponseDto>>))]
        public async Task<IActionResult> getSuggestions(Guid userId
            , [FromServices]IGetFriendSuggestionsService getFriendSuggestionsService)
            =>await _presenter.Handle(userId, getFriendSuggestionsService);   
    }
}
