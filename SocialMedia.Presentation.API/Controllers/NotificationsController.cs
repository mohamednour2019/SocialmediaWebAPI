using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.NotificatinosInterfaces;
using SocialMedia.Core.ServicesInterfaces.SSEInterfaces;
using System.Collections.Concurrent;

namespace SocialMedia.Presentation.API.Controllers
{
    public class NotificationsController:BaseController
    {
        private static readonly ConcurrentDictionary<Guid, HttpResponse> _connections = new();

        [HttpGet("{UserConnectionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task Connect([FromRoute]Guid UserConnectionId, [FromServices]ISendLiveNotificationService sendLiveNotificationService)
        {
          await sendLiveNotificationService.Connect(HttpContext, UserConnectionId);
        }


        [HttpGet("list/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(ResponseModel<List<GetNotificationResponseDto>>))]
        public async Task<IActionResult> getNotifications(Guid userId, [FromServices]IGetNotificationsService getNotificationsService)
            =>await _presenter.Handle(new GetNotificationsRequestDto() { UserId=userId}, getNotificationsService);



    }
}
