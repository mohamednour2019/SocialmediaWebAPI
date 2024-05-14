using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using SocialMedia.Core.DTO_S.RequestDto_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.RepositoriesInterfaces
{
    public interface IFriendshipRepository
    {
        Task<List<User>> GetFriendWithType(Guid userId,FriendshipStatus type);

        Task<FriendsRelationship?> GetFriendShipStatus(AddFriendRequestDto requestDto);

        //Task DeleteFriendWithType(DeleteFriendshipRequestDto requestDto, FriendshipStatus type);
    }
}
