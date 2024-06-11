using Microsoft.AspNetCore.Http;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.NotificatinosInterfaces;
using SocialMedia.Core.ServicesInterfaces.SSEInterfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SocialMedia.Core.Services.SSEServices
{
    public class SendLiveNotificationService : ISendLiveNotificationService
    {
        private static readonly ConcurrentDictionary<Guid, HttpResponse> _connections = new();
        public async Task Connect(HttpContext context,Guid UserConnectionId)
        {
            context.Response.Headers.Add("Content-Type", "text/event-stream");
            HttpResponse userResponse = context.Response;
            _connections[UserConnectionId] = userResponse;
            await Task.Delay(-1,context.RequestAborted);

 
        }

        public static async Task SendNotification(Guid userId
            , ResponseModel<GetNotificationResponseDto>notificationResponse)
        {
            if (_connections.TryGetValue(userId, out HttpResponse response))
            {
                string jsonData = JsonSerializer.Serialize(notificationResponse);
                await response.WriteAsync($"data:{jsonData}\n\n");
                await response.Body.FlushAsync();
              
            }
        }

        public async Task Disconnect(Guid userId)
        {
            try
            {
                _connections.TryRemove(userId, out _);
            }
            catch (Exception ex)
            {

            }
        }

    }
}
