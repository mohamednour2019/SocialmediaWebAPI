using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.ServicesInterfaces.OTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.OTPServices
{
    public class GenerateOtpService : IGenerateOtpService
    {
        public async Task<string> GenerateOTP(Guid userId)
        {
            OTP otp = new OTP()
            {

            };
            return null;
        }
    }
}
