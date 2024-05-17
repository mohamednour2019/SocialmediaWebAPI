using Microsoft.AspNetCore.SignalR;
using SocialMedia.Core.ServicesInterfaces.HubInterfaces;

namespace SocialMedia.Core.Services.HubServices
{
    public class NotificationHubService : Hub,INotificationHubService
    {
        public async Task SendNotification()
        {
            await Clients.All.SendAsync("getNotification", "hello man");
        }
    }
}
