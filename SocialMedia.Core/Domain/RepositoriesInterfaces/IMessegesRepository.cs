using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.RepositoriesInterfaces
{
    public interface IMessegesRepository
    {
        Task<List<Message>> GetMessagesAsync(GetChatMessegesRequestDto requestDto);

        Task AddMessgeAsync(Message message);
    }
}
