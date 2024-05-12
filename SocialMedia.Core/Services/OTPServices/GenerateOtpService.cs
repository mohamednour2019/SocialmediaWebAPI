using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.OTP;


namespace SocialMedia.Core.Services.OTPServices
{
    public class GenerateOtpService : IGenerateOtpService
    {
        Random generator = new Random();

        public GenerateOtpResponseDto GenerateOTP()
        => new GenerateOtpResponseDto()
        {
            OTP = generator.Next(100000, 999999 + 1).ToString(),
            ExpireyDate = DateTime.Now.AddMinutes(10)
        };

        
    }
}
