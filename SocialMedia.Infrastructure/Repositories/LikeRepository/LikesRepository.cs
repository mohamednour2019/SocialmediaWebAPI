using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Like.ResponseDTOs;
using SocialMedia.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.LikeRepository
{
    public class LikesRepository:ILikesRepository
    {
        private AppDbContext _appDbContext;
        private const int PageSize = 10;

        public LikesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<LikeResponseDto>>getLikes(Guid postId, int pageNumber)
        => await _appDbContext.Likes.Include(x=>x.User).Where(x=>x.PostId== postId)
            .Select(x=>new LikeResponseDto()
            {
                UserId = x.UserId,
                PostId = postId,
                FirstName=x.User.FirstName,
                LastName=x.User.LastName,
                UserProfilePictureUrl=x.User.ProfilePicture
            })
            .Skip((pageNumber*PageSize)-PageSize).Take(PageSize)
            .ToListAsync();
    }
}
