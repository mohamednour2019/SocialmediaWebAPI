using AutoMapper;
using SocialMedia.Core.Domain.Entities;
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
    public class RejectFriendRequestService :GenericService<FriendsRelationship>, IRejectFriendRequestService
    {
        public RejectFriendRequestService(IMapper mapper,IGenericRepository<FriendsRelationship>repository):
            base(mapper,repository)
        { 

        }

        public async Task<RejectFriendRequestResponseDto> Perform(RejectFriendRequestRequestDto requestDto)
        {
            await _repository.Delete(requestDto.SenderId, requestDto.ReciverId);
            return new RejectFriendRequestResponseDto();
        }
    }
}
