using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Infrastructure.DatabaseContext;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.DTO_S.Post.ResponseDTOs;

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

        public async Task AddPost(Post post)
            => await _context.Posts.AddAsync(post);

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
                    isShared = x.IsShared,
                    PostSharingData = x.IsShared == true ? new PostSharingResponseDto()
                    {
                        UserFirstName = x.SharedFromUser.FirstName,
                        UserLastName = x.SharedFromUser.LastName,
                        UserId = x.ShareFromUserId,
                        UserProfilePictureUrl = x.SharedFromUser.ProfilePicture
                    } : null
                })
                .FirstOrDefaultAsync();


        public async Task<List<GetUserPostsResponseDto>> GetPostsAsync(Guid userId, int pageNumber) =>
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
                    isLiked = x.Likes.Any(x => x.UserId == userId),
                    isShared = x.IsShared,
                    PostSharingData=x.IsShared==true?new PostSharingResponseDto()
                    {
                        UserFirstName=x.SharedFromUser.FirstName,
                        UserLastName=x.SharedFromUser.LastName,
                        UserId=x.ShareFromUserId,
                        UserProfilePictureUrl=x.SharedFromUser.ProfilePicture
                    }:null
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
                isShared = x.IsShared,
                PostSharingData = x.IsShared == true ? new PostSharingResponseDto()
                {
                    UserFirstName = x.SharedFromUser.FirstName,
                    UserLastName = x.SharedFromUser.LastName,
                    UserId = x.ShareFromUserId,
                    UserProfilePictureUrl = x.SharedFromUser.ProfilePicture
                } : null
            }))
            .OrderByDescending(x => x.DateTime)
            .Skip((pageNumber * _pageSize) - _pageSize).Take(_pageSize)
            .ToListAsync();

                
    }
}
