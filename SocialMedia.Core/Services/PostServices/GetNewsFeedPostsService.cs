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
        public GetNewsFeedPostsService(IPostRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseModel<List<GetNewsFeedPostsResponseDto>>> Perform(GetNewsFeedPostsRequestDto requestDto)
        {
            List<GetNewsFeedPostsResponseDto>?posts = await _repository.GetNewsFeedPostsAsync(requestDto.UserId,requestDto.PageNumber);
            return new ResponseModel<List<GetNewsFeedPostsResponseDto>>()
            {
                Success = true,
                Message = null,
                Data = posts
            };

        }
    }
}
