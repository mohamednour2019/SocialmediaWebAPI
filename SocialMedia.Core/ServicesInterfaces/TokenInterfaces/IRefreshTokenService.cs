using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Token.RequestDTOs;
using SocialMedia.Core.DTO_S.Token.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.TokenInterfaces
{
    public interface IRefreshTokenService:IGenericService<RefreshTokenRequestDto,ResponseModel<RefreshTokenResponseDto>>
    {
    }
}
