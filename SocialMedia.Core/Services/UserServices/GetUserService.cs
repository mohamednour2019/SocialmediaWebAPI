using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
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
    public class GetUserService : IGetUserService
    {
        private IGenericRepository<User> _genericRepository;
        private IFriendshipRepository _friendshipRepository;
        private IMapper _mapper;
        public GetUserService(IGenericRepository<User> genericRepository
            , IFriendshipRepository friendshipRepository
            ,IMapper mapper)
        {
            _mapper= mapper;    
            _genericRepository = genericRepository;
            _friendshipRepository = friendshipRepository;

        }
        public async Task<ResponseModel<GetUserResponseDto>> Perform(GetUserRequestDto requestDto)
        {
            User user = await _genericRepository.FindAsync(requestDto.RequestedUserId);
            GetUserResponseDto response=_mapper.Map<GetUserResponseDto>(user);
            FriendsRelationship? relationship=await _friendshipRepository
                .GetFriendShipStatus(new AddFriendRequestDto { CurrentUserId = requestDto.CurrentUserId
                , FriendId = requestDto.RequestedUserId });
            if(relationship is null)
            {
                relationship = new FriendsRelationship()
                {
                    Type = FriendshipStatus.NotFriends
                };
            }
            response.FirstUserId=relationship.FirstUserId;
            response.SecondUserId=relationship.SecondUserId;
            response.Type = relationship.Type;
            return new ResponseModel<GetUserResponseDto>()
            {
                Success = true,
                Message = null,
                Data = response
            };
        }


    }
}
