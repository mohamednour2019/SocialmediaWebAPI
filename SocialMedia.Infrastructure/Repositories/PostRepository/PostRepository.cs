using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Infrastructure.DatabaseContext;
using System.Security.Cryptography.X509Certificates;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using Microsoft.Diagnostics.Tracing.Parsers.Tpl;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.DTO_S.Like.ResponseDTOs;

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

        public async Task<Post> GetPostAsync(Guid postId) =>
                 await _context.Posts
                .Include(x => x.Likes)
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .Include(x => x.User)
                .Select(x=>new
                 Post()
                 {
                     Id = x.Id,
                     UserId = x.UserId,
                     ImageUrl = x.ImageUrl,
                     Likes = x.Likes.Select(x => new Like() { UserId = x.UserId, PostId = x.PostId }).ToList(),
                     Content = x.Content,
                     DateTime = x.DateTime,
                     User = new User() { FirstName = x.User.FirstName, LastName = x.User.LastName, ProfilePicture = x.User.ProfilePicture },
                     Comments = x.Comments.Select(x => new Comment() { Id = x.Id, DateCreated = x.DateCreated, UserId = x.UserId, Content = x.Content, PostId = x.PostId, User = new User() { FirstName = x.User.FirstName, LastName = x.User.LastName, ProfilePicture = x.User.ProfilePicture } }).ToList()

                 })
                .FirstOrDefaultAsync(x => x.Id == postId);


        public async Task<List<GetUserPostsResponseDto>> GetPostsAsync(Guid userId) =>
            await _context.Posts
                .Include(x=>x.User)
                .Include(x => x.Likes)
                .Include(x=>x.Comments)
                .Where(x => x.UserId == userId)
                .Select(x=>new GetUserPostsResponseDto()
                {
                    PostId = x.Id,
                    DateTime = x.DateTime,
                    Content = x.Content,
                    PostImageUrl = x.ImageUrl,
                    UserId = x.UserId,
                    UserFirstName = x.User.FirstName,
                    UserLastName = x.User.LastName,
                    UserProfilePictureUrl = x.User.ProfilePicture,
                    LikesCount =x.Likes.Count(),
                    CommentsCount=x.Comments.Count(),
                    isLiked=x.Likes.Any(x=>x.UserId == userId),
                })
                .OrderBy(x => x.DateTime)
                .ToListAsync();
        public async Task<List<GetNewsFeedPostsResponseDto>> GetNewsFeedPostsAsync(Guid userId)
         => await _context.Friends
            .Include(x => x.SecondUser)
            .ThenInclude(x => x.Posts)
            .ThenInclude(x => x.Comments)
            .Include(x => x.SecondUser)
            .ThenInclude(x => x.Posts)
            .ThenInclude(x => x.Likes)
            .Where(x => x.FirstUserId == userId && x.Type == FriendshipStatus.Friends)
            .SelectMany(x => x.SecondUser.Posts.Select(x => new GetNewsFeedPostsResponseDto()
            {
                PostId = x.Id,
                DateTime = x.DateTime,
                Content = x.Content,
                PostImageUrl = x.ImageUrl,
                UserId = x.UserId,
                UserFirstName = x.User.FirstName,
                UserLastName = x.User.LastName,
                UserProfilePictureUrl = x.User.ProfilePicture,
                LikesCount = x.Likes.Count(),
                CommentsCount = x.Comments.Count(),
                isLiked = x.Likes.Any(x => x.UserId == userId),
            }))
            .OrderBy(x => x.DateTime)
            .ToListAsync();

                
    }
}
