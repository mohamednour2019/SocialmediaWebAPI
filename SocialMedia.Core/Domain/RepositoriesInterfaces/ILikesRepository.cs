using SocialMedia.Core.DTO_S.Like.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.RepositoriesInterfaces
{
    public interface ILikesRepository
    {
        Task<List<LikeResponseDto>> getLikes(Guid postId);
    }
}
