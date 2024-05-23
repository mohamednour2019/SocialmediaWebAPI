using SendGrid.Helpers.Mail;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.HubInterfaces
{
    public interface IMessengerHubService
    {
        Task<string> SendMessage(Guid userId,Guid senderId,string message);
    }
}
