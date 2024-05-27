using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.UserServices
{
    public class SearchUserService : ISearchUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        public SearchUserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;   
        }
        public async Task<ResponseModel<List<SearchUserResponseDto>>> Perform(SearchUserRequestDto requestDto)
        {
            List<User> result;
            string [] keywordParts=requestDto.searchKeyWord.Split(' ');
            if (keywordParts.Length==1)
            {
                result=await _userRepository.SearchUserAsync(keywordParts);
            }
            else
            {
                result=await _userRepository.SearchUserAsync(keywordParts);
            }
            List<SearchUserResponseDto>response=_mapper.Map <List<SearchUserResponseDto>>(result);
            return new ResponseModel<List<SearchUserResponseDto>>
            {
                Data = response,
                Success = true,
                Message = null
            };
        }
    }
}
