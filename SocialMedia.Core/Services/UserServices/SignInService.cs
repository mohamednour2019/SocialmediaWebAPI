using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.Services.SSEServices;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;
using SocialMedia.SharedKernel.CustomExceptions;

namespace SocialMedia.Core.Services.UserServices
{
    public class SignInService : ISignInService
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private IMapper _mapper;
        public SignInService(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public async Task<ResponseModel<SignInResponseDto>> Perform(SignInRequestDto requestDto)
        {
            User? user = await _userManager.FindByEmailAsync(requestDto.UserName);
            if (user is not null)
            {
                SignInResult signInResult = await _signInManager.PasswordSignInAsync(requestDto.UserName
               , requestDto.Password
               , isPersistent: false
               , lockoutOnFailure: false);
                if (!signInResult.Succeeded)
                {
                    throw new ViolenceValidationException("incorrect password!");
                }
                SignInResponseDto response = _mapper.Map<SignInResponseDto>(user);
                return new ResponseModel<SignInResponseDto>()
                {
                    Success = true,
                    Message = new List<string>() { "successfully signed in!" },
                    Data = response
                };
            }
            else
            {
                throw new ViolenceValidationException("user not registered!");
            }
        }
    }
}
