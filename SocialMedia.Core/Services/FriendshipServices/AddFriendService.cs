using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.FriendshipServices
{
    public class AddFriendService :GenericService<FriendsRelationship>, IAddFriendService
    {
        public AddFriendService(IMapper mapper,IGenericRepository<FriendsRelationship>repository)
            :base(mapper,repository)
        {
        }
        public async Task<AddFriendResponseDto> Perform(AddFriendRequestDto requestDto)
        {
            FriendsRelationship friendRequest = _mapper.Map<FriendsRelationship>(requestDto);
            friendRequest.Type = FriendshipStatus.FriendRequest.ToString();
            try
            {
                await _repository.AddAsync(friendRequest);
            }catch(Exception ex)
            {
                throw new Exception("Friend Request Already Sent!");
            }
            //FriendsRelationship ? friendsRelationship = 
            //    await _friendshipRepository.GetFriendShipStatus(requestDto);
            //if(friendsRelationship is null) {
            //    FriendsRelationship friendRequest= _mapper.Map<FriendsRelationship>(requestDto);
            //    friendRequest.Type = "FriendRequest";
            //    await _repository.AddAsync(friendRequest);
            //}
            //else if(friendsRelationship.Type == "FriendRequest") {
            //    friendsRelationship.Type = "Friends";
            //    await _unitOfWork.SaveChangeAsync();
            //}
            return new AddFriendResponseDto();

        }
    }
}
