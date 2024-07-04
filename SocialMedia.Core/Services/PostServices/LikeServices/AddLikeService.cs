using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Like.ResponseDTOs;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.Services.SSEServices;
using SocialMedia.Core.ServicesInterfaces.NotificatinosInterfaces;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.LikeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.PostServices.LikeServices
{
    public class AddLikeService : IAddLikeService
    {
        private IGetNotificationService _notificationService;
        private IMapper _mapper;
        private IGenericRepository<Like> _repository;
        private IGenericRepository<Post> _postRepository;
        public AddLikeService(IMapper mapper,IGenericRepository<Like>repository,
            IGetNotificationService notificationService
            ,IGenericRepository<Post>genericRepository)
        {
            _postRepository= genericRepository;
            _notificationService=notificationService;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ResponseModel<LikeResponseDto>> Perform(AddLikeRequestDto requestDto)
        {
            Like like = _mapper.Map<Like>(requestDto);
            like.Id = Guid.NewGuid();
            Post post = await _postRepository.FindAsync(requestDto.PostId);
            if(post.UserId != requestDto.UserId) {

                try
                {
                    await _repository.AddAsync(like);
                }
                catch (Exception ex)
                {
                    throw new Exception("Something Went Wrong!");
                }
                try
                {
                    var notification = await _notificationService.Perform((Guid)like.Id);
                    await SendLiveNotificationService.SendNotification(notification.Data.UserId, notification);
                }
                catch (Exception ex) { }
            }
            else
            {
                try
                {
                    await _repository.AddAsync(like);
                }
                catch (Exception ex)
                {
                    throw new Exception("Something Went Wrong!");
                }
            }
         
            return new ResponseModel<LikeResponseDto>() { Success = true };
        }
    }
}
