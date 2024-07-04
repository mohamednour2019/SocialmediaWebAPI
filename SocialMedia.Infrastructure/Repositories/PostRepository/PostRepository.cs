using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Infrastructure.DatabaseContext;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.DTO_S.Post.ResponseDTOs;
using Microsoft.Extensions.Hosting;

namespace SocialMedia.Infrastructure.Repositories.PostRepository
{
    public class PostRepository : IPostRepository
    {
        private int _pageSize = 10;
        private AppDbContext _context;
        public PostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AddPostResponseDto> AddPost(Post post)
        {
            try
            { 
                await _context.Posts.AddAsync(post); 
                await _context.SaveChangesAsync();
            }catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            return await _context.Posts.
                Where(x => x.Id == post.Id)
                .Select(x => new AddPostResponseDto()
                {
                    PostId = x.Id,
                    DateTime = x.DateTime,
                    Content = x.Content,
                    PostImageUrl = x.ImageUrl,
                    UserId = x.UserId,
                    UserFirstName = x.User.FirstName,
                    UserLastName = x.User.LastName,
                    UserProfilePictureUrl = x.User.ProfilePicture,
                })
               .FirstOrDefaultAsync();

        }

        public async Task<GetUserPostsResponseDto> GetPostAsync(Guid postId, Guid userId) =>
                 await _context.Posts
                .Where(x=>x.Id==postId)
                .Select(x => new GetUserPostsResponseDto()
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
                    PostSharingData = x.SharedFromPostId != null ? new PostSharingResponseDto()
                    {
                         PostId = x.SharedPost.Id,
                         DateTime = x.SharedPost.DateTime,
                         Content = x.SharedPost.Content,
                         UserId = x.SharedPost.UserId,
                         PostImageUrl = x.SharedPost.ImageUrl,
                         UserFirstName = x.SharedPost.User.FirstName,
                         UserLastName = x.SharedPost.User.LastName,
                         UserProfilePictureUrl = x.SharedPost.User.ProfilePicture,
                    } : null
                })
                .FirstOrDefaultAsync();


        public async Task<List<GetUserPostsResponseDto>> GetPostsAsync(Guid userId, int pageNumber, Guid requestedUserId) =>
            await _context.Posts
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
                    LikesCount = x.Likes.Count(),
                    CommentsCount = x.Comments.Count(),
                    isLiked = x.Likes.Any(x => x.UserId == requestedUserId),
                    PostSharingData = x.SharedFromPostId != null ? new PostSharingResponseDto()
                    {
                        PostId = x.SharedPost.Id,
                        DateTime = x.SharedPost.DateTime,
                        Content = x.SharedPost.Content,
                        UserId = x.SharedPost.UserId,
                        PostImageUrl = x.SharedPost.ImageUrl,
                        UserFirstName = x.SharedPost.User.FirstName,
                        UserLastName = x.SharedPost.User.LastName,
                        UserProfilePictureUrl = x.SharedPost.User.ProfilePicture,
                    } : null
                })
                .OrderByDescending(x => x.DateTime)
                .Skip((pageNumber* _pageSize) - _pageSize).Take(_pageSize)
                .ToListAsync();

        public async Task<List<GetNewsFeedPostsResponseDto>> GetNewsFeedPostsAsync(Guid userId, int pageNumber)
         => await _context.Friends
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
                PostSharingData = x.SharedFromPostId != null ? new PostSharingResponseDto()
                {
                    PostId = x.SharedPost.Id,
                    DateTime = x.SharedPost.DateTime,
                    Content = x.SharedPost.Content,
                    UserId = x.SharedPost.UserId,
                    PostImageUrl = x.SharedPost.ImageUrl,
                    UserFirstName = x.SharedPost.User.FirstName,
                    UserLastName = x.SharedPost.User.LastName,
                    UserProfilePictureUrl = x.SharedPost.User.ProfilePicture,
                } : null
            }
            ))
            .OrderByDescending(x => x.DateTime)
            .Skip((pageNumber * _pageSize) - _pageSize).Take(_pageSize)
            .ToListAsync();

        public async Task<SharePostResponseDto> SharePost(Post post)
        {
            try
            {
                await _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return await _context.Posts.
                Where(x => x.Id == post.Id)
                .Select(x => new SharePostResponseDto()
                {
                    PostId = x.Id,
                    DateTime = x.DateTime,
                    Content = x.Content,
                    PostImageUrl = x.ImageUrl,
                    UserId = x.UserId,
                    UserFirstName = x.User.FirstName,
                    UserLastName = x.User.LastName,
                    UserProfilePictureUrl = x.User.ProfilePicture,
                    PostSharingData= new PostSharingResponseDto()
                    {
                        PostId = x.SharedPost.Id,
                        DateTime = x.SharedPost.DateTime,
                        Content = x.SharedPost.Content,
                        UserId = x.SharedPost.UserId,
                        PostImageUrl = x.SharedPost.ImageUrl,
                        UserFirstName = x.SharedPost.User.FirstName,
                        UserLastName = x.SharedPost.User.LastName,
                        UserProfilePictureUrl = x.SharedPost.User.ProfilePicture,
                    }
                })
               .FirstOrDefaultAsync();
        }
    }
}
