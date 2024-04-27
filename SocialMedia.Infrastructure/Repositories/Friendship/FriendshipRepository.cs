using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.Friendship
{
    public class FriendshipRepository : IFriendshipRepository
    {
        private AppDbContext _context;
        public FriendshipRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetFriendRequests(Guid userId)
            => await _context.Friends?.Include(x => x.FirstUser)
               .Where(x => x.SecondUserId == userId)
               ?.Select(x => x.FirstUser)?.ToListAsync()!;

        public async Task<FriendsRelationship?> GetFriendShipStatus(AddFriendRequestDto requestDto)
        {
            FriendsRelationship? friendsRelationship
            =   await _context.Friends.FindAsync(requestDto.CurrentUserId, requestDto.FriendId);

            if(friendsRelationship is null) {

               friendsRelationship = await _context.Friends.FindAsync(requestDto.FriendId,requestDto.CurrentUserId);
            }
            return friendsRelationship;
        }
    }
}
