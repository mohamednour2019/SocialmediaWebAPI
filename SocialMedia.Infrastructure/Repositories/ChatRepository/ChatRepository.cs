using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Chat.ResponseDTOs;
using SocialMedia.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.ChatRepository
{
    public class ChatRepository : IChatRepository
    {
        const int PAGE_SIZE= 15;
        private AppDbContext _appDbContext;

        public ChatRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<GetUserChatResponseDto>> GetUserChats(Guid userId,int pageNumber)
        {
            return await _appDbContext.Chats.Where(x => x.FirstUserId == userId)
            .Select(x => new GetUserChatResponseDto()
            {
                FirstName = x.SecondUser.FirstName,
                LastName = x.SecondUser.LastName,
                UserId=x.SecondUserId,
                ProfilePictureURL = x.SecondUser.ProfilePicture,
                LastMessageContent = x.Message.Content,
                LastMessageDate = x.Message.CreatedDate

            })
            .OrderByDescending(x=>x.LastMessageDate)
            .Skip((pageNumber*PAGE_SIZE)-PAGE_SIZE)
            .Take(PAGE_SIZE)
            .ToListAsync();
        }
    }
}
