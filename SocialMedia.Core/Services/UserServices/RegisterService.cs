using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.Services.FriendshipServices;
using SocialMedia.Core.ServicesInterfaces;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using SocialMedia.Core.ServicesInterfaces.OTP;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;
using SocialMedia.SharedKernel.CustomExceptions;


namespace SocialMedia.Core.Services.UserServices
{
    public class RegisterService : IRegisterService
    {
        private UserManager<User> _userManager;
        private IMapper _mapper;
        private IGenerateOtpService _generateOtpService;
        private IAddSelfRelationFriendshipService _addSelfRelationFriendshipService;
        private ISendEmailService _sendEmailService;
        public RegisterService(UserManager<User> userManager
            , IMapper mapper,IGenerateOtpService generateOtpService
            ,ISendEmailService sendEmailService,
            IAddSelfRelationFriendshipService addSelfRelationFriendshipService)
        {
            _addSelfRelationFriendshipService = addSelfRelationFriendshipService;
            _sendEmailService = sendEmailService;
            _userManager = userManager;
            _generateOtpService = generateOtpService;
            _userManager = userManager;
            _mapper = mapper;

        }
        public async Task<ResponseModel<RegisterResponseDto>> Perform(RegisterRequestDto requestDto)
        {
            User user = _mapper.Map<User>(requestDto);
            user.Id = new Guid();
            GenerateOtpResponseDto otpInfo = _generateOtpService.GenerateOTP();
            user.OTP = otpInfo.OTP;
            user.OtpExpiration = otpInfo.ExpireyDate;
            IdentityResult result = await _userManager.CreateAsync(user, requestDto.Password);
            if (!result.Succeeded)
            {
                throw new ViolenceValidationException(string.Join('\n', result.Errors.Select(x => x.Description)));
            }
            await _addSelfRelationFriendshipService.AddSelfRlation(user.Id);
            //_sendEmailService.SendEmail(user.OTP, user.Email);
            return new ResponseModel<RegisterResponseDto>()
            {
                Success = true,
                Message = new List<string>() { "user successfully registered" },
                Data = new RegisterResponseDto() { UserId = user.Id }
            };
        }
    }
}
