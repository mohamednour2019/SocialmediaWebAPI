using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.ServicesInterfaces.TokenHandler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialMedia.Core.Services.TokenHanlderService
{
    public class TokenHandler : ITokenHandler
    {
        private IConfiguration _configuration;
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public string CreateToken(User user)
        {


            //create user claims
            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Email.ToString()),
                new Claim(ClaimTypes.Name,user.FirstName+" "+user.LastName)
            };

            //security key for hashing
            byte[] securityKey = Encoding.ASCII.GetBytes(_configuration["JWT:SecurityKey"]);
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(securityKey);


            //hashing algorithm
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey
                , SecurityAlgorithms.HmacSha256);


            //token settings
            string IssuerValue = _configuration["JWT:Issuer"];
            string AudienceValue = _configuration["JWT:Audience"];
            double ExpirationMinutes = Convert.ToDouble(_configuration["JWT:EXPIRATION_MINUTES"]);
            DateTime ExpirationDate = DateTime.UtcNow.AddMinutes(ExpirationMinutes);

            JwtSecurityToken JwtToken = new JwtSecurityToken(issuer: IssuerValue
                , audience: AudienceValue
                , claims: claims
                , expires: ExpirationDate
                , signingCredentials: signingCredentials);

            //generating token
            string token =_jwtSecurityTokenHandler.WriteToken(JwtToken);
            return token;
        }
    }
}
