using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.PostServices.CommentServices
{
    public class UpdateCommentService : GenericService<Comment>, IUpdateCommentService
    {
        private IUnitOfWork _unitOfWork;
        public UpdateCommentService(IMapper mapper,
             IUnitOfWork unitOfWork
            ,IGenericRepository<Comment>repository)
            :base(mapper,repository)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UpdateCommentResponseDto> Perform(UpdateCommentRequestDto requestDto)
        {
           Comment comment = await  _repository.FindAsync(requestDto.CommentId);
            if (comment is null||comment.UserId != requestDto.UserId)
                throw new Exception("You Can't Edit this Comment!");

            comment.Content= requestDto.Content;
            await _unitOfWork.SaveChangeAsync();
            UpdateCommentResponseDto responseDto=_mapper.Map<UpdateCommentResponseDto>(comment);
            return responseDto;
        }
    }
}
