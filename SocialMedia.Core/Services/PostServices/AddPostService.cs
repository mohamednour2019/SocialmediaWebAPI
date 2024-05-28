using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.AzureBlobInterfaces;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces;

namespace SocialMedia.Core.Services.PostServices
{
    public class AddPostService :IAddPostService
    {
        private IMapper _mapper;
        private IGenericRepository<Post> _repository;
        private IUploadImageServie _uploadImageServie;
        public AddPostService(IMapper mapper,IGenericRepository<Post>repository
            ,IUploadImageServie uploadImageServie) 
        {
            _mapper = mapper;
            _repository = repository;   
            _uploadImageServie = uploadImageServie; 
        }

        public async Task<ResponseModel<AddPostResponseDto>> Perform(AddPostRequestDto requestDto)
        {
            Post post = _mapper.Map<Post>(requestDto);
            post.Id = Guid.NewGuid();
            post.DateTime= DateTime.Now;
            if(requestDto.Image is not null)
            {
                try
                {
                    post.ImageUrl= await _uploadImageServie.UploadImage(requestDto.Image);
                }
                catch(Exception ex) { }
            }
            try
            {
                await _repository.AddAsync(post);

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            AddPostResponseDto responseDto = _mapper.Map<AddPostResponseDto>(post);
            return new ResponseModel<AddPostResponseDto>()
            {
                Success = true,
                Message = null,
                Data = responseDto
            };
        }
    }
}
