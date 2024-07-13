using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Comment.RequestDTOs;
using SocialMedia.Core.DTO_S.Comment.ResponseDTOs;
using SocialMedia.Core.DTO_S.Reply.RequestDTOs;
using SocialMedia.Core.DTO_S.Reply.ResponseDTOs;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.CommentRepository
{
    public class CommentRepository : ICommentRepository
    {
        private AppDbContext _context;
        private const int PageSize = 10;
        public CommentRepository(AppDbContext context)
        {
            _context= context;
        }


        public async Task<Comment> FindAsyncWithDependent(Guid id, string dependent)
        {
            Comment ?comment = await _context.Comments.Include(dependent)
                                   .FirstOrDefaultAsync(x => x.Id == id);
            return comment;
        }

        public async Task<List<GetCommentResponseDto>> GetComments(GetCommentsRequestDto requestDto)
            => await _context.Comments
                .Include(x=>x.User)
                .Where(x=>x.PostId== requestDto.PostId&&x.CommentParentId==null)
                .Select(x=>new GetCommentResponseDto()
                {
                    CommentId=x.Id,
                    PostId= requestDto.PostId,
                    UserId=x.UserId,
                    Content=x.Content,
                    DateCreated=x.DateCreated,
                    FirstName=x.User.FirstName,
                    LastName=x.User.LastName,
                    ProfilePictureUrl=x.User.ProfilePicture,
                    isLiked = x.Likes.Any(x => x.UserId == x.UserId),
                    RepliesCount=x.Replies.Count(),
                    Replies =x.Replies.Take(1).Select(x => new GetCommentResponseDto()
                    {
                        CommentId = x.Id,
                        Content = x.Content,
                        DateCreated = x.DateCreated,
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName,
                        ProfilePictureUrl = x.User.ProfilePicture,
                        CommentParentId = x.CommentParentId,
                        PostId = requestDto.PostId,
                        UserId = x.UserId,
                        RepliesCount = x.Replies.Count(),
                        isLiked =x.Likes.Any(x=>x.UserId==x.UserId)
                    }).ToList()
                })
                .OrderByDescending(x=>x.DateCreated)
                .Skip((requestDto.PageNumber*PageSize)-PageSize).Take(PageSize)
                .ToListAsync();

        public async Task<GetCommentResponseDto> AddReplyAsync(Comment requestDto)
        {
            await _context.Comments.AddAsync(requestDto);
            await _context.SaveChangesAsync();
            return await _context.Comments.Where(x => x.Id == requestDto.Id)
                .Take(1).Select(x => new GetCommentResponseDto()
            {
                CommentId = x.Id,
                Content = x.Content,
                DateCreated = x.DateCreated,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                ProfilePictureUrl = x.User.ProfilePicture,
                CommentParentId = x.CommentParentId,
                PostId = requestDto.PostId,
                UserId = x.UserId
            }).FirstOrDefaultAsync();
        }

        public async Task<List<GetCommentResponseDto>> GetReplies(GetCommentRepliesRequestDto requestDto)
        {
           return await  _context.Comments.Where(x => x.CommentParentId == requestDto.CommentParentId)
                .Select(x => new GetCommentResponseDto()
                {
                    CommentId = x.Id,
                    PostId = x.PostId,
                    UserId = x.UserId,
                    Content = x.Content,
                    DateCreated = x.DateCreated,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    ProfilePictureUrl = x.User.ProfilePicture,
                    isLiked = x.Likes.Any(x => x.UserId == x.UserId),
                    RepliesCount = x.Replies.Count(),
                    Replies = x.Replies.Take(1).Select(x => new GetCommentResponseDto()
                    {
                        CommentId = x.Id,
                        Content = x.Content,
                        DateCreated = x.DateCreated,
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName,
                        ProfilePictureUrl = x.User.ProfilePicture,
                        CommentParentId = x.CommentParentId,
                        PostId = x.PostId,
                        UserId = x.UserId,
                        RepliesCount = x.Replies.Count(),
                        isLiked = x.Likes.Any(x => x.UserId == x.UserId)
                    }).ToList()
                }).OrderByDescending(x=>x.DateCreated).ToListAsync();
        }
    }
}
