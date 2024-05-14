using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces
{
    public interface IUnfriendService:IGenericService<DeleteFriendshipRequestDto,ResponseModel<DeleteFriendshipResponseDto>>
    {
    }
}
