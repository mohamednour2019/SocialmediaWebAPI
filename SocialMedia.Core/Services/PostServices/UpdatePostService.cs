using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces;


namespace SocialMedia.Core.Services.PostServices
{
    public class UpdatePostService :GenericService<Post> , IUpdatePostService
    {
        private IUnitOfWork _unitOfWork;
        public UpdatePostService(IMapper mapper, IGenericRepository<Post> repository,
            IUnitOfWork unitOfWork)
            : base(mapper, repository)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UpdatePostResponseDto> Perform(UpdatePostRequestDto requestDto)
        {
            Post post = _mapper.Map<Post>(requestDto);
            post = await _repository.FindAsync(post.Id);
            post.Content = requestDto.Content;
            await _unitOfWork.SaveChangeAsync();
            UpdatePostResponseDto updatePostResponseDto=_mapper.Map<UpdatePostResponseDto>(post);
            return updatePostResponseDto;
        }
    }
}
