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
    public class UnfriendService :IUnfriendService
    {
        IGenericRepository<FriendsRelationship> _repository;

        public UnfriendService(IGenericRepository<FriendsRelationship>repository)
        { 
            _repository = repository;
        }

        public  async Task<ResponseModel<DeleteFriendshipResponseDto>> Perform(DeleteFriendshipRequestDto requestDto)
        {
            await _repository.Delete(requestDto.SenderId, requestDto.ReciverId);
            await _repository.Delete(requestDto.ReciverId, requestDto.SenderId);
            string message = "the friend has been remove from your friends list.";
            return new ResponseModel<DeleteFriendshipResponseDto>()
            {
                Success = true,
                Data = null,
                Message = new List<string>() {message}
            };

        }
    }
}
