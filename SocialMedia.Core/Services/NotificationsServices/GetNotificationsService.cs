using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.NotificatinosInterfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.NotificationsServices
{
    public class GetNotificationsService : IGetNotificationsService
    {
        private INotificationRepository _notificationRepository;
        private IMapper _mapper;
        public GetNotificationsService(INotificationRepository repository,IMapper mapper)
        {
            _notificationRepository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseModel<List<GetNotificationResponseDto>>> Perform(GetNotificationsRequestDto requestDto)
        {
            List<Notification> notifications = await _notificationRepository.GetNotifications(requestDto.UserId);
            List<GetNotificationResponseDto>response=_mapper.Map<List<GetNotificationResponseDto>>(notifications);
            return new ResponseModel<List<GetNotificationResponseDto>>()
            {
                Success = true,
                Message = null,
                Data = response
            };
        }
    }
}
