using Microsoft.AspNetCore.Http;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.ServicesInterfaces.SSEInterfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            context.Response.Headers.Add("Cache-Control", "no-cache");
            context.Response.Headers.Add("Connection", "keep-alive");

            HttpResponse userResponse = context.Response;
            _connections[UserConnectionId] = userResponse;

            try
            {
                await Task.Delay(-1, context.RequestAborted);
            }
            finally
            {
                _connections.TryRemove(UserConnectionId, out _);
            }
        }

        public static async Task SendNotification(Guid userId, string message)
        {
            if (_connections.TryGetValue(userId, out HttpResponse response))
            {
                if (!response.HttpContext.RequestAborted.IsCancellationRequested)
                {
                    try
                    {
                        await response.WriteAsync($"data: {message}\n\n");
                        await response.Body.FlushAsync();
                    }
                    catch (Exception ex)
                    {
                        _connections.TryRemove(userId, out _);
                    }
                }
                else
                {
                    _connections.TryRemove(userId, out _);
                }
            }
        }

    }
}
