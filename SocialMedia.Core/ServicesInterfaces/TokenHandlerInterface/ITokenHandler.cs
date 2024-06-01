using SocialMedia.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.TokenHandler
{
    public interface ITokenHandler
    {
        string CreateToken(User user);
    }
}
