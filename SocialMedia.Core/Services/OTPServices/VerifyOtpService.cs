using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.OTPInterfaces;
using SocialMedia.SharedKernel.CustomExceptions;


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
        public async Task<ResponseModel<VerifyOtpResponseDto>> Perform(VerifyOtpRequestDto requestDto)
        {
            User user = await _repository.FindAsync(requestDto.UserId);
            if (user is null) throw new ViolenceValidationException("user not found"!);
            if (user.OtpExpiration < DateTime.Now)
            {
                throw new ViolenceValidationException("otp has been expired!");
            }
            else if(user.OtpExpiration > DateTime.Now && user.OTP != requestDto.OTPCode)
            {
                throw new ViolenceValidationException("invalid otp!");
            }
            else
            {
                user.EmailConfirmed = true;
                await _unitOfWork.SaveChangeAsync();
            }
            return new ResponseModel<VerifyOtpResponseDto>()
            {
                Success = true,
                Message = new List<string>() {"user has been verified successfully!"},
                Data = null
            };

        }
    }
}
