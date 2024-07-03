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
        private IPostRepository _postRepository;
        private IUploadImageServie _uploadImageServie;
        public AddPostService(IMapper mapper
            , IUploadImageServie uploadImageServie, IPostRepository postRepository)
        {
            _mapper = mapper;
            _uploadImageServie = uploadImageServie;
            _postRepository = postRepository;
        }

        public async Task<ResponseModel<AddPostResponseDto>> Perform(AddPostRequestDto requestDto)
        {
            Post post = new Post()
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now,
                UserId = requestDto.UserId,
                Content = requestDto.Content
            };

            if(requestDto.Image is not null)
            {
                try
                {
                    post.ImageUrl= await _uploadImageServie.UploadImage(requestDto.Image);
                }
                catch(Exception ex) { }
            }


           AddPostResponseDto response= await _postRepository.AddPost(post);


            
            return new ResponseModel<AddPostResponseDto>()
            {
                Success = true,
                Message = null,
                Data = response
            };
        }
    }
}
