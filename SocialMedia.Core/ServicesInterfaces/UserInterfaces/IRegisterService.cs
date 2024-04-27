using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.UserInterfaces
{
    public interface IRegisterService : IGenericService<RegisterRequestDto, RegisterResponseDto>
    {
    }
}
