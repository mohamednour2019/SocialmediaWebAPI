using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Core.ServicesInterfaces.TokenInterfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialMedia.Core.Services.TokenServices
{
    public class GetClaimsFromToken : IGetClaimsFromToken
    {
        private IConfiguration _configuration;
        private string _audience;
        private string _issuer;
        private string _key;
        public GetClaimsFromToken(IConfiguration configuration)
        {
            _configuration = configuration;
            _audience = _configuration["JWT:Audeience"];
            _issuer = _configuration["JWT:Issuer"];
            _key = _configuration["JWT:SecurityKey"];
        }

        ClaimsPrincipal IGetClaimsFromToken.GetClaimsFromToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateActor = true,
                ValidateIssuer = true,
                ValidateLifetime = false,
                ValidAudience = _audience,
                ValidIssuer =_issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key))
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            ClaimsPrincipal claimsPrincipal = jwtSecurityTokenHandler.ValidateToken(token
            , tokenValidationParameters
            , out SecurityToken validatedToken);

            if (validatedToken is not JwtSecurityToken jwtSecurityToken
            || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256
            , StringComparison.OrdinalIgnoreCase))
            {
                throw new SecurityTokenExpiredException("sign in again!");
            }

            return claimsPrincipal;
        }
    }
}
