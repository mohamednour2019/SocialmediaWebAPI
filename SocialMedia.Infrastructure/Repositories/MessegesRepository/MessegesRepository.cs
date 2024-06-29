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

namespace SocialMedia.Infrastructure.Repositories.MessegesRepository
{
    public class MessegesRepository : IMessegesRepository
    {
        private AppDbContext _appDbContext;
        private const int PAGE_SIZE = 15;
        public MessegesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddMessgeAsync(Message message)
        {
            await _appDbContext.Messages.AddAsync(message);
            await _appDbContext.SaveChangesAsync(); 
        }

        public async Task<List<Message>> GetMessagesAsync(GetChatMessegesRequestDto requestDto)=>
               await _appDbContext.Messages
                .Where(x => (x.SenderId == requestDto.FirstUserId && x.ReciverId == requestDto.SedondUserId) ||
                (x.SenderId == requestDto.SedondUserId && x.ReciverId == requestDto.FirstUserId))
                .OrderByDescending(x=>x.CreatedDate)   
                .Skip((requestDto.PageNumber*PAGE_SIZE) - PAGE_SIZE)
                .Take(PAGE_SIZE)
                .ToListAsync();
    }
}
