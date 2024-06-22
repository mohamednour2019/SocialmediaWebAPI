using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Token;
using SocialMedia.Core.DTO_S.Token.OutputDTOs;
using SocialMedia.Core.ServicesInterfaces.TokenHandler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SocialMedia.Core.Services.TokenHanlderService
{
    public class TokenHandlerService : ITokenHandlerService
    {
        private IConfiguration _configuration;
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        IGenericRepository<UserRefreshToken> _userRefreshTokenRepository;
        public TokenHandlerService(IConfiguration configuration, IGenericRepository<UserRefreshToken> userRefreshTokenRepository)
        {
            _userRefreshTokenRepository = userRefreshTokenRepository;
            _configuration = configuration;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }


        public TokenOutputDto CreateToken(User user)
        {
            //create user claims
            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Email.ToString()),
                new Claim(ClaimTypes.Name,user.FirstName+" "+user.LastName),
                new Claim(ClaimTypes.Role,"RiverUser")
            };

            //security key for hashing
            byte[] securityKey = Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]);
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(securityKey);


            //hashing algorithm
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey
                , SecurityAlgorithms.HmacSha256);


            //token settings
            string IssuerValue = _configuration["JWT:Issuer"];
            string AudienceValue = _configuration["JWT:Audeience"];
            double ExpirationMinutes = Convert.ToDouble(_configuration["JWT:EXPIRATION_MINUTES"]);
            DateTime ExpirationDate = DateTime.UtcNow.AddMinutes(ExpirationMinutes);

            JwtSecurityToken JwtToken = new JwtSecurityToken(issuer: IssuerValue
                , audience: AudienceValue
                , claims: claims
                , expires: ExpirationDate
                , signingCredentials: signingCredentials);

            //generating token
            string token =_jwtSecurityTokenHandler.WriteToken(JwtToken);
            return new TokenOutputDto()
            {
                Token = token,
                ExpiresIn = ExpirationDate
            };
        }


        public string GenerateRefreshToken()
        {
            byte[] randomNumber = new byte[64];
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<string> CreateRefreshToken(Guid userId)
        {
            double refreshTokenExpirationDays = Convert.ToDouble(_configuration["JWT:REFRESH_TOKEN_EXPIRATION_DAYS"]);
            UserRefreshToken refreshToken = new UserRefreshToken()
            {
                UserId = userId,
                ExpiresIn = DateTime.UtcNow.AddDays(refreshTokenExpirationDays),
                RefreshToken = GenerateRefreshToken()
            };
            try
            {
                await _userRefreshTokenRepository.Delete(userId);
                await _userRefreshTokenRepository.AddAsync(refreshToken);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return refreshToken.RefreshToken;
        }

    }
}
