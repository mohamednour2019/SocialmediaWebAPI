using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces;


namespace SocialMedia.Core.Services.PostServices
{
    public class UpdatePostService :IUpdatePostService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IGenericRepository<Post> _repository;
        public UpdatePostService(IMapper mapper, IGenericRepository<Post> repository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ResponseModel<UpdatePostResponseDto>> Perform(UpdatePostRequestDto requestDto)
        {
            Post post = _mapper.Map<Post>(requestDto);
            post = await _repository.FindAsync(post.Id);
            post.Content = requestDto.Content;
            await _unitOfWork.SaveChangeAsync();
            UpdatePostResponseDto updatePostResponseDto=_mapper.Map<UpdatePostResponseDto>(post);
            return new ResponseModel<UpdatePostResponseDto>
            {
                Success = true,
                Message = null,
                Data = updatePostResponseDto
            };
        }
    }
}
