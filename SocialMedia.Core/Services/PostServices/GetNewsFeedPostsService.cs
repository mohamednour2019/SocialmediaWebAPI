using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces;
using SocialMedia.SharedKernel.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.PostServices
{
    public class GetNewsFeedPostsService : IGetNewsFeedPostsService
    {
        private IPostRepository _repository;
        private IMapper _mapper;
        public GetNewsFeedPostsService(IPostRepository repository,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ResponseModel<List<GetNewsFeedPostsResponseDto>>> Perform(GetNewsFeedPostsRequestDto requestDto)
        {
            List<Post>?posts = await _repository.GetNewsFeedPostsAsync(requestDto.UserId);
            List<GetNewsFeedPostsResponseDto> postsResponse=null;
            if (posts is not null)
            {
                postsResponse = _mapper.Map<List<GetNewsFeedPostsResponseDto>>(posts);

            }
            return new ResponseModel<List<GetNewsFeedPostsResponseDto>>()
            {
                Success = true,
                Message = null,
                Data = postsResponse
            };

        }
    }
}
