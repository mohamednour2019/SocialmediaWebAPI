using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Reply.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.RepositoriesInterfaces
{
    public interface IReplyRepository
    {
        Task<AddReplyResponseDto> AddReplyAsync(Reply requestDto);
    }
}
