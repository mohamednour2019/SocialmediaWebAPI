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
    public class DeleteCommentService :GenericService<Comment>, IDeleteCommentService
    {
        private ICommentRepository _commentRepository;
        public DeleteCommentService(IMapper mapper,IGenericRepository<Comment> repository,ICommentRepository commentRepository)
            :base(mapper,repository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<DeleteCommentResponseDto> Perform(DeleteCommentRequestDto requestDto)
        {
            Comment comment = await _commentRepository.FindAsyncWithDependent(requestDto.CommentId,nameof(comment.Post));
            if(comment is not null)
            {
                if (comment.UserId != requestDto.UserId &&
                    comment.Post.UserId != requestDto.UserId)
                {

                    throw new Exception("You Can't delete This Comment!");
                }
            }
            await _repository.Delete(requestDto.CommentId);
            return new DeleteCommentResponseDto();

        }
    }
}
