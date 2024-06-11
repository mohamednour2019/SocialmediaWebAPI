using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.PostServices
{
    public class GetUserPostsService : IGetUserPostsService
    {
        private IPostRepository _repository;
        private IMapper _mapper;
        public GetUserPostsService(IPostRepository repository,IMapper mapper)
        {
            _mapper=mapper;
            _repository= repository;
        }
        public async Task<ResponseModel<List<GetUserPostsResponseDto>>> Perform(GetUserPostsRequestDto requestDto)
        {
            List<GetUserPostsResponseDto>userPosts=await _repository.GetPostsAsync(requestDto.UserId);
            var responseResult=new ResponseModel<List<GetUserPostsResponseDto>>()
            {
                Success = true,
                Message=null,
                Data = null
            };
            if (userPosts.Count<1)
            {
                responseResult.Message = new List<string>() { "you don't have any posts." };
                return responseResult;
            }
            responseResult.Data = userPosts;
            return responseResult;
        }
    }
}
