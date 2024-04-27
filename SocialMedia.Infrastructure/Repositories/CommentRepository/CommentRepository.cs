using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
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
    }
}
