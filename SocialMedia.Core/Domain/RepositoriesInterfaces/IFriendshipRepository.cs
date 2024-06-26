﻿using SocialMedia.Core.Domain.Entities;
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
        Task<List<User>> GetUserFriends(Guid userId);

        Task<FriendsRelationship?> GetFriendShipStatus(AddFriendRequestDto requestDto);
        Task<List<User>> GetFriendRequests(Guid userId);
        Task<List<User>> GetFirendSuggestions(Guid userId);
        Task<List<User>> GetOnlineFriends(Guid userId);
        Task RemoveFriendAsync(Guid FirstUserId, Guid SecondUserId);
        //Task DeleteFriendWithType(DeleteFriendshipRequestDto requestDto, FriendshipStatus type);
    }
}
