using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Reply.ResponseDTOs;
using SocialMedia.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.ReplyRepository
{
    public class ReplyRepository : IReplyRepository
    {
        private AppDbContext _appDbContext;

        public ReplyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<AddReplyResponseDto> AddReplyAsync(Reply requestDto)
        {
            await _appDbContext.Replies.AddAsync(requestDto);
            await _appDbContext.SaveChangesAsync();
            return await _appDbContext.Replies.Where(x => x.Id == requestDto.Id)
            .Select(x => new AddReplyResponseDto()
            {
                Id = x.Id,
                Content = x.Content,
                DateCreated = x.DateCreated,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                ProfilePictureUrl = x.User.ProfilePicture,
                ReplyId = requestDto.ReplyId,
                UserId = requestDto.UserId,
                CommentId=x.CommentId,
                Depth = 1
            }).FirstOrDefaultAsync();
        }

    }
}
