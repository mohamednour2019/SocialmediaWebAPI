using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Infrastructure.DatabaseContext;


namespace SocialMedia.Infrastructure.Repositories.PostRepository
{
    public class PostRepository : IPostRepository
    {
        private AppDbContext _context;
        public PostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddPost(Post post)
            => await _context.Posts.AddAsync(post);
    }
}
