using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.ServicesInterfaces.OTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.OTPServices
{
    public class GenerateOtpService:IGenerateOtpService
    {
        Random generator = new Random();

        public string GenerateOTP()
        => generator.Next(100000, 999999 + 1).ToString();

        
    }
}
