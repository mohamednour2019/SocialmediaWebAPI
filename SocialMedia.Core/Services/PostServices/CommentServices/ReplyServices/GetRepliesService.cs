using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Comment.ResponseDTOs;
using SocialMedia.Core.DTO_S.Reply.RequestDTOs;
using SocialMedia.Core.DTO_S.Reply.ResponseDTOs;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces.ReplyInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.PostServices.CommentServices.ReplyServices
{
    public class GetRepliesService : IGetRepliesService
    {
        private ICommentRepository _commentRepository;

        public GetRepliesService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<ResponseModel<List<GetCommentResponseDto>>> Perform(GetCommentRepliesRequestDto requestDto)
        {
            List<GetCommentResponseDto> response = await _commentRepository.GetReplies(requestDto);

            return new ResponseModel<List<GetCommentResponseDto>>
            {
                Data = response,
                Message = null,
                Success = true
            };
        }
    }
}
