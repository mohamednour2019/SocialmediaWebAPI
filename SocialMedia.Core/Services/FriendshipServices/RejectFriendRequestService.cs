﻿using AutoMapper;
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
    public class RejectFriendRequestService : IRejectFriendRequestService
    {
        IGenericRepository<FriendsRelationship> _repository;
        public RejectFriendRequestService(IGenericRepository<FriendsRelationship> repository)
        {
            _repository = repository;
        }
        public async Task<ResponseModel<DeleteFriendshipResponseDto>> Perform(DeleteFriendshipRequestDto requestDto)
        {
            await _repository.Delete(requestDto.SenderId, requestDto.ReciverId);
            string message = "request has been rejected.";
            return new ResponseModel<DeleteFriendshipResponseDto>()
            {
                Success = true,
                Data = null,
                Message = new List<string>() { message }
            };
        }
    }
}
