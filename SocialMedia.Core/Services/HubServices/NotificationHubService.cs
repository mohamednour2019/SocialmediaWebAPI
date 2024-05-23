using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SocialMedia.Core.ServicesInterfaces.HubInterfaces;

namespace SocialMedia.Core.Services.HubServices
{
    public class NotificationHubService : Hub,INotificationHubService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NotificationHubService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SendNotification(string message)
        {

            await Clients.All.SendAsync(message);
        }
    }
}
