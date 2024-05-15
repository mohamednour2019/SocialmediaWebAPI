using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.RepositoriesInterfaces
{
    public interface IPostRepository
    {
        Task AddPost(Post post);
        Task<List<Post>> GetPostsAsync(Guid userId);
        Task<List<Post>> GetNewsFeedPostsAsync(Guid userId);

        Task<Post> GetPostAsync(Guid postId);
    }
}
