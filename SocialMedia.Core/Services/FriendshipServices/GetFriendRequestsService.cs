using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.FriendshipServices
{
    public class GetFriendRequestsService : IGetFriendRequestsService
    {
        private readonly IMapper _mapper;
        private readonly IFriendshipRepository _friendshipRepository;
        public GetFriendRequestsService(IMapper mapper
            , IFriendshipRepository repository)
        {
            _friendshipRepository = repository;
            _mapper = mapper;
        }
        public async Task<GetFriendRequestsResponseDto> Perform(Guid requestDto)
        {
           List<User>?users= await _friendshipRepository.GetFriendRequests(requestDto);
            if (users is null)
                throw new Exception("You Don't have Friend Requests!");

            GetFriendRequestsResponseDto friendRequests= new GetFriendRequestsResponseDto();
            friendRequests.FriendRequests = _mapper.Map<List<SignInResponseDto>>(users);
            return friendRequests;
        }
    }
}
