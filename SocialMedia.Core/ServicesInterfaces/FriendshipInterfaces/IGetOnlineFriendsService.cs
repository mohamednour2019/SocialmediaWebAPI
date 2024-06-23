using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Friendship.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces
{
    public interface IGetOnlineFriendsService:IGenericService<Guid,ResponseModel<List<GetOnlineFriendsResponseDto>>>
    {
    }
}
