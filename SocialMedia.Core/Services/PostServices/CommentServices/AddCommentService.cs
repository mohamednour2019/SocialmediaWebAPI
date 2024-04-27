using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces;

namespace SocialMedia.Core.Services.PostServices.CommentServices
{
    public class AddCommentService : GenericService<Comment>, IAddCommentService
    {
        public AddCommentService(IMapper mapper,IGenericRepository<Comment>repository)
            :base(mapper,repository)
        {
            
        }
        public async Task<AddCommentResponseDto> Perform(AddCommentRequestDto requestDto)
        {
            Comment comment=_mapper.Map<Comment>(requestDto);
            comment.Id = Guid.NewGuid();
            comment.DateCreated = DateTime.Now;
            try
            {
                await _repository.AddAsync(comment);
            }catch (Exception ex)
            {
                throw new Exception("Something Went Wrong!");
            }
            AddCommentResponseDto responseDto = _mapper.Map<AddCommentResponseDto>(comment);
            return responseDto;
        }
    }
}
