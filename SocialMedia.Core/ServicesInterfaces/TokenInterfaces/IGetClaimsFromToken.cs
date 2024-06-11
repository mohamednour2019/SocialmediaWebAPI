using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.TokenInterfaces
{
    public interface IGetClaimsFromToken
    {
        ClaimsPrincipal GetClaimsFromToken(string token);
    }
}
