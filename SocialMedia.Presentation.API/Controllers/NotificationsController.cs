using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
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




    }
}
