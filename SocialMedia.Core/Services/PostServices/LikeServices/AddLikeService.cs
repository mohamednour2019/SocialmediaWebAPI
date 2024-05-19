using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
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
        public AddLikeService(IMapper mapper,IGenericRepository<Like>repository,
            IGetNotificationService notificationService)
        {
            _notificationService=notificationService;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ResponseModel<AddLikeResponseDto>> Perform(AddLikeRequestDto requestDto)
        {
            Like like = _mapper.Map<Like>(requestDto);
            like.NotificationId = Guid.NewGuid();
            try
            {
                await _repository.AddAsync(like);
            }catch(Exception ex)
            {
                throw new Exception("Something Went Wrong!");
            }
            try
            {
                var notification = await _notificationService.Perform(like.NotificationId);
                await SendLiveNotificationService.SendNotification(notification.Data.UserId, notification);
            }
            catch(Exception ex) { }
            return new ResponseModel<AddLikeResponseDto>() { Success = true };
        }
    }
}
