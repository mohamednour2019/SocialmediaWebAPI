using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.OTPInterfaces;


namespace SocialMedia.Core.Services.OTPServices
{
    public class VerifyOtpService : IVerifyOtpService
    {
        private IGenericRepository<User> _repository;
        private IUnitOfWork _unitOfWork;
        public VerifyOtpService(IGenericRepository<User> repository
            ,IUnitOfWork unitOfWork) {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<VerifyOtpResponseDto> Perform(VerifyOtpRequestDto requestDto)
        {
            User user = await _repository.FindAsync(requestDto.UserId);
            if (user.OtpExpiration < DateTime.Now)
            {
                throw new InvalidOperationException("otp has been expired!");
            }
            else if(user.OtpExpiration > DateTime.Now && user.OTP != requestDto.OTPCode)
            {
                throw new InvalidOperationException("invalid otp!");
            }
            else
            {
                user.EmailConfirmed = true;
                await _unitOfWork.SaveChangeAsync();
            }
            return new VerifyOtpResponseDto();

        }
    }
}
