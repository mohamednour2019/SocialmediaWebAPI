using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Token.OutputDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.TokenHandler
{
    public interface ITokenHandlerService
    {
        TokenOutputDto CreateToken(User user);
        string GenerateRefreshToken();
        Task<string> CreateRefreshToken(Guid userId);
    }
}
