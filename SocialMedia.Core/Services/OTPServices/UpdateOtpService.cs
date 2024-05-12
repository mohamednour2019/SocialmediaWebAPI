using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.OTP;
using SocialMedia.Core.ServicesInterfaces.OTPInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.OTPServices
{
    public class UpdateOtpService : IUpdateOtpService
    {
        private IGenericRepository<User> _userRepository;
        private IUnitOfWork _unitOfWork;
        private IGenerateOtpService _generateOtpService;
        public UpdateOtpService(IGenericRepository<User> repository,
            IUnitOfWork unitOfWork,IGenerateOtpService generateOtpService)
        {
            _generateOtpService = generateOtpService;
            _unitOfWork=unitOfWork;
            _userRepository=repository;
        }
        public async Task<ResponseModel<UpdateOtpResponseDto>> Perform(UpdateOtpRequestDto requestDto)
        {
            User user=await _userRepository.FindAsync(requestDto.UserId);
            GenerateOtpResponseDto otpInfo = _generateOtpService.GenerateOTP();
            if (user is null) throw new Exception("user not found");
            user.OTP = otpInfo.OTP;
            user.OtpExpiration = otpInfo.ExpireyDate;
            await _unitOfWork.SaveChangeAsync();
            return new ResponseModel<UpdateOtpResponseDto>()
            {
                Success = true,
                Message = new List<string>() {"a new otp has been sent to your email."},
                Data = null
            };
        }
    }
}
