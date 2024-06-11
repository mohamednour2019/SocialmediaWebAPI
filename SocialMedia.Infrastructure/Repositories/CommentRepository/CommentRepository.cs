using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Comment.ResponseDTOs;
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

        public async Task<List<GetCommentResponseDto>> GetComments(Guid postId)
            => await _context.Comments
                .Include(x=>x.User)
                .Where(x=>x.PostId==postId)
                .Select(x=>new GetCommentResponseDto()
                {
                    CommentId=x.Id,
                    PostId=postId,
                    UserId=x.UserId,
                    Content=x.Content,
                    DateCreated=x.DateCreated,
                    FirstName=x.User.FirstName,
                    LastName=x.User.LastName,
                    ProfilePictureUrl=x.User.ProfilePicture
                }).OrderBy(x=>x.DateCreated).ToListAsync();

    }
}
