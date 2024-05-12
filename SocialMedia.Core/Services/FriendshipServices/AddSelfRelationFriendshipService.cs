using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.FriendshipServices
{
    public class AddSelfRelationFriendshipService: IAddSelfRelationFriendshipService
    {
        private IGenericRepository<FriendsRelationship> _repository;
        public AddSelfRelationFriendshipService(IGenericRepository<FriendsRelationship> repository)
        {
            _repository = repository;
        }
        public async Task AddSelfRlation(Guid UserId)
        {
            FriendsRelationship serlfRelation = new FriendsRelationship()
            {
                FirstUserId = UserId,
                SecondUserId = UserId,
                Type = FriendshipStatus.Friends
            };
            await _repository.AddAsync(serlfRelation);
        }
    }
}
