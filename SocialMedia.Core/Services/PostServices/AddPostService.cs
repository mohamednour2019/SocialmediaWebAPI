using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces;

namespace SocialMedia.Core.Services.PostServices
{
    public class AddPostService :GenericService<Post>, IAddPostService
    {
        public AddPostService(IMapper mapper, IGenericRepository<Post> repository) 
            : base(mapper, repository)
        {
        }

        public async Task<AddPostResponseDto> Perform(AddPostRequestDto requestDto)
        {
            Post post = _mapper.Map<Post>(requestDto);
            post.Id = Guid.NewGuid();
            post.DateTime= DateTime.Now;
            try
            {
                await _repository.AddAsync(post);

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            AddPostResponseDto responseDto = _mapper.Map<AddPostResponseDto>(post);
            return responseDto;
        }
    }
}
