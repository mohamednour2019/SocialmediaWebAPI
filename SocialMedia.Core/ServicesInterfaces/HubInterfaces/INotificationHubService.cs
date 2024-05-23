

namespace SocialMedia.Core.ServicesInterfaces.HubInterfaces
{
    public interface INotificationHubService
    {
        Task SendNotification(string message);
    }
}
