﻿using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.PostServices
{
    public class DeletePostService :IDeletePostService
    {
        private IMapper _mapper;
        private IGenericRepository<Post> _repository;
        private INotificationRepository _notificationRepository;
        public DeletePostService(IMapper mapper,IGenericRepository<Post>repository
            ,INotificationRepository notificationRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _notificationRepository = notificationRepository;
        }
        public async Task<ResponseModel<DeletePostResponseDto>> Perform(DeletePostRequestDto requestDto)
        {
           await _repository.Delete(requestDto.PostId);
           await _notificationRepository.DeletePostNotifications(requestDto.PostId);
            return new ResponseModel<DeletePostResponseDto>
            {
                Success = true,
                Message = new List<string>() { "post has been deleted!" },
                Data = new DeletePostResponseDto() { PostId = requestDto.PostId }
            };
        }
    }
}
