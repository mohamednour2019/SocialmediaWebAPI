using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.PostServices
{
    public class GetPostService : IGetPostService
    {
        private IPostRepository _repository;
        private IMapper _mapper;
        public GetPostService(IPostRepository repository, IMapper mapper)
        {
             _mapper=mapper;
            _repository = repository;
        }
        public async Task<ResponseModel<GetUserPostsResponseDto>> Perform(Guid requestDto)
        {
            Post post= await _repository.GetPostAsync(requestDto);
            GetUserPostsResponseDto response= _mapper.Map<GetUserPostsResponseDto>(post);
            return new ResponseModel<GetUserPostsResponseDto>()
            {
                Message = null,
                Success = true,
                Data = response
            };
        }
    }
}
