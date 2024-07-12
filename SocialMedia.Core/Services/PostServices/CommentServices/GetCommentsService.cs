using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Comment.RequestDTOs;
using SocialMedia.Core.DTO_S.Comment.ResponseDTOs;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.PostServices.CommentServices
{
    public class GetCommentsService : IGetCommentsService
    {
        private ICommentRepository _commentRepository;

        public GetCommentsService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<ResponseModel<List<GetCommentResponseDto>>> Perform(GetCommentsRequestDto requestDto)
        {
            List<GetCommentResponseDto>comments= await _commentRepository
                .GetComments(requestDto);
            return new ResponseModel<List<GetCommentResponseDto>>()
            {
                Data = comments,
                Message = null,
                Success = true
            };
        }
    }
}
