using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.SSEInterfaces
{
    public interface ISendLiveNotificationService
    {
        Task Connect(HttpContext context, Guid UserConnectionId);
        Task Disconnect(Guid userId);
    }
}
