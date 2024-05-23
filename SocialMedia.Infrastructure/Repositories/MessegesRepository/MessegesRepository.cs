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
                .OrderBy(x=>x.CreatedDate)
                .ToListAsync();
    }
}
