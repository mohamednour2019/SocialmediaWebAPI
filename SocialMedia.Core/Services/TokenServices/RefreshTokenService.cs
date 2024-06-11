using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Token.OutputDTOs;
using SocialMedia.Core.DTO_S.Token.RequestDTOs;
using SocialMedia.Core.DTO_S.Token.ResponseDTOs;
using SocialMedia.Core.ServicesInterfaces.TokenHandler;
using SocialMedia.Core.ServicesInterfaces.TokenInterfaces;
using System.Security.Claims;

namespace SocialMedia.Core.Services.TokenServices
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private IGetClaimsFromToken _getClaimsFromToken;
        private IGenericRepository<UserRefreshToken> _refreshTokenRepository;
        private ITokenHandlerService _tokenHandlerService;
        private UserManager<User> _userManager;

        public RefreshTokenService(IGetClaimsFromToken getClaimsFromToken
            , IGenericRepository<UserRefreshToken> refreshTokenRepository
            , ITokenHandlerService tokenHandlerService
            , UserManager<User> userManager)
        {
            _userManager= userManager;
            _tokenHandlerService = tokenHandlerService;
            _getClaimsFromToken = getClaimsFromToken;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<ResponseModel<RefreshTokenResponseDto>> Perform(RefreshTokenRequestDto requestDto)
        {
            ClaimsPrincipal claims = _getClaimsFromToken.GetClaimsFromToken(requestDto.Token);
            if(claims is null)
            {
                await _refreshTokenRepository.Delete(requestDto.UserId);
                throw new SecurityTokenExpiredException("login again!");
            }
            string userId = claims.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = await _userManager.FindByIdAsync(userId);
            UserRefreshToken? refreshToken = await _refreshTokenRepository.FindAsync(user.Id);
            if (refreshToken is null ||refreshToken.RefreshToken!=requestDto.RefreshToken
                ||refreshToken.ExpiresIn < DateTime.UtcNow)
            {
                await _refreshTokenRepository.Delete(requestDto.UserId);
                throw new SecurityTokenExpiredException("login again!");
            }

            TokenOutputDto newToken=_tokenHandlerService.CreateToken(user);
            string newRefreshToken=await _tokenHandlerService.CreateRefreshToken(user.Id);

            RefreshTokenResponseDto response = new RefreshTokenResponseDto()
            {
                Token = newToken.Token,
                RefreshToken = newRefreshToken,
                ExpiresIn = newToken.ExpiresIn
            };

            return new ResponseModel<RefreshTokenResponseDto>()
            {
                Success = true,
                Data = response,
                Message = null
            };
        }
    }
}
