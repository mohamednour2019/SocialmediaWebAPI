using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;


namespace SocialMedia.Core.Services.UserServices
{
    public class RegisterService : IRegisterService
    {
        private UserManager<User> _userManager;
        private IMapper _mapper;
        public RegisterService(UserManager<User> userManager
            , IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;

        }
        public async Task<RegisterResponseDto> Perform(RegisterRequestDto requestDto)
        {
            User user = _mapper.Map<User>(requestDto);
            user.Id = new Guid();
            IdentityResult result = await _userManager.CreateAsync(user, requestDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join('\n', result.Errors.Select(x => x.Description)));
            }

            return new RegisterResponseDto() { succeded = true };
        }
    }
}
