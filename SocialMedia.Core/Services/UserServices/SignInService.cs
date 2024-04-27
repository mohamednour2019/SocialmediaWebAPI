using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;

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
        public async Task<SignInResponseDto> Perform(SignInRequestDto requestDto)
        {
            User? user = await _userManager.FindByEmailAsync(requestDto.UserName);
            if (user is not null)
            {
                SignInResult signInResult = await _signInManager.PasswordSignInAsync(requestDto.UserName
               , requestDto.Password
               , isPersistent: requestDto.StaySignIn
               , lockoutOnFailure: true);
                if (!signInResult.Succeeded)
                {
                    throw new Exception("incorrect password!");
                }
                SignInResponseDto response = _mapper.Map<SignInResponseDto>(user);
                return response;
            }
            else
            {
                throw new Exception("user not registered!");
            }
        }
    }
}
