using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces
{
    public interface ISendEmailService
    {
        void SendEmail(string otp, string userEmail);
    }
}
