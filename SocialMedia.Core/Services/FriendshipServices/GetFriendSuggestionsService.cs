using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.FriendshipServices
{
    public class GetFriendSuggestionsService : IGetFriendSuggestionsService
    {
        private IFriendshipRepository _friendshipRepository;
        private IMapper _mapper;
        public GetFriendSuggestionsService(IFriendshipRepository friendshipRepository
            ,IMapper mapper)
        {
            _mapper = mapper;
            _friendshipRepository = friendshipRepository;
        }
        public async Task<ResponseModel<List<GetFriendsSuggestionsResponseDto>>> Perform(Guid requestDto)
        {
            List<User>suggestions= await _friendshipRepository.GetFirendSuggestions(requestDto);
            List<GetFriendsSuggestionsResponseDto> response = _mapper.Map<List<GetFriendsSuggestionsResponseDto>>(suggestions);

            return new ResponseModel<List<GetFriendsSuggestionsResponseDto>>()
            {
                Data = response,
                Success = true,
                Message = null
            };

        }
    }
}
