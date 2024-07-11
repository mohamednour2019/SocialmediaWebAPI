using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Reply.RequestDTOs;
using SocialMedia.Core.DTO_S.Reply.ResponseDTOs;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces.ReplyInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.PostServices.CommentServices.ReplyServices
{
    public class AddReplyService : IAddReplyService
    {
        private IReplyRepository _replyRepository;

        public AddReplyService(IReplyRepository replyRepository)
        {
            _replyRepository = replyRepository;
        }

        public async Task<ResponseModel<AddReplyResponseDto>> Perform(AddReplyRequestDto requestDto)
        {
            Reply reply = new Reply()
            {
                Id = Guid.NewGuid(),
                Content = requestDto.Content,
                CommentId = requestDto.CommentId,
                UserId = requestDto.UserId,
                ReplyId = requestDto.ReplyId,
                DateCreated = DateTime.Now,
            };
            AddReplyResponseDto response;

            try
            {
                response=await _replyRepository.AddReplyAsync(reply);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new ResponseModel<AddReplyResponseDto>
            {
                Data = response,
                Message = null,
                Success = true
            };
        }
    }
}
