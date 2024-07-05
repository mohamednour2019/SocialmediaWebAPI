using SocialMedia.Core.DTO_S.Chat.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.RepositoriesInterfaces
{
    public interface IChatRepository
    {
        Task<List<GetUserChatResponseDto>> GetUserChats(Guid userId, int pageNumber);
    }
}
