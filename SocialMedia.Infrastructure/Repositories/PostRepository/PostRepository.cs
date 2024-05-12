using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Infrastructure.DatabaseContext;
using System.Security.Cryptography.X509Certificates;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

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

        public async Task<List<Post>> GetPostsAsync(Guid userId)=>
            await _context.Posts.Include(x=>x.Likes)
            .Include(x=>x.Comments)
            .Where(x=>x.UserId == userId)
            .OrderByDescending(x => x.DateTime)
            .ToListAsync();
        public async Task<List<Post>> GetNewsFeedPostsAsync(Guid userId)
        {
            var newsFeedPosts = _context.Friends
            .Include(x => x.SecondUser)
            .ThenInclude(x => x.Posts)
            .ThenInclude(x => x.Comments)
            .Include(x => x.SecondUser)
            .ThenInclude(x => x.Posts)
            .ThenInclude(x => x.Likes)
            .Where(x => x.FirstUserId == userId && x.Type == FriendshipStatus.Friends)
            .SelectMany(x => x.SecondUser.Posts)
            .OrderByDescending(x => x.DateTime);

            return await newsFeedPosts.ToListAsync();
        }

                
    }
}
