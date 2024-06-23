using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Friendship.ResponseDTOs;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.FriendshipServices
{
    public class GetOnlineFriendsService : IGetOnlineFriendsService
    {
        private IFriendshipRepository _friendshipRepository;
        private IMapper _mapper;

        public GetOnlineFriendsService(IFriendshipRepository friendshipRepository
            , IMapper mapper)
        {
            _friendshipRepository = friendshipRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<GetOnlineFriendsResponseDto>>> Perform(Guid requestDto)
        {
            List<User>onlineUsers=await _friendshipRepository.GetOnlineFriends(requestDto);
            List<GetOnlineFriendsResponseDto> response = null;
            if (onlineUsers is not null )
            {
                response = _mapper.Map<List<GetOnlineFriendsResponseDto>>(onlineUsers);
            }

            return new ResponseModel<List<GetOnlineFriendsResponseDto>>
            {
                Success = true,
                Data = response,
                Message = null
            };
            
        }
    }
}
