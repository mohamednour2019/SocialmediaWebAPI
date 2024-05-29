using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
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
        public async Task<List<User>> GetUserFriends(Guid userId)=>
            await _context.Friends.Where(x => x.SecondUserId == userId && x.FirstUserId != userId && x.Type == FriendshipStatus.Friends)
            .Select(x => x.FirstUser)?.ToListAsync()!;

        public async Task<List<User>>GetFriendRequests(Guid userId)=>
            await _context.Friends.Where(x=>x.SecondUserId==userId&&x.Type==FriendshipStatus.FriendRequest)
            .Select(x => x.FirstUser)?.ToListAsync()!;

        public async Task<FriendsRelationship?> GetFriendShipStatus(AddFriendRequestDto requestDto)
        {
            FriendsRelationship? friendsRelationship
            = await _context.Friends.FindAsync(requestDto.CurrentUserId, requestDto.FriendId);

            if (friendsRelationship is null) {

                friendsRelationship = await _context.Friends.FindAsync(requestDto.FriendId, requestDto.CurrentUserId);
            }
            return friendsRelationship;
        }

        public async Task<List<User>> GetFirendSuggestions(Guid userId)
        {
            var userRelations = await _context.Friends?.Include(x => x.FirstUser).Include(x => x.SecondUser)
           .Where(x => (x.SecondUserId == userId && x.FirstUserId != userId) ||
            (x.FirstUserId == userId && x.SecondUserId != userId))?
           .Select(x => x.FirstUserId == userId ? x.SecondUser : x.FirstUser).ToListAsync();

            var suggestions = _context.Users.Where(x=>x.Id!=userId).Take(30);
            if(userRelations is not null)
            {
                suggestions=suggestions.Where(x=>!userRelations.Contains(x));
            }   
            return await suggestions.ToListAsync();
        }
        
        public async Task RemoveFriendAsync(Guid FirstUserId,Guid SecondUserId)
        {
            var friendsRelationship = await _context.Friends.FirstOrDefaultAsync(x => 
            (x.FirstUserId == FirstUserId && x.SecondUserId == SecondUserId)
            || (x.FirstUserId == SecondUserId && x.SecondUserId == FirstUserId));
            if(friendsRelationship is not null) {
                _context.Friends.Remove(friendsRelationship);
                await _context.SaveChangesAsync();
            }

        }


        public bool IsFriends(Guid CurrentUser, Guid FriendUser)
        => _context.Friends.Any(x => (x.FirstUserId == CurrentUser && x.SecondUserId == FriendUser) ||
            (x.SecondUserId == CurrentUser && x.FirstUserId == FriendUser));


    }
}
