using Microsoft.AspNetCore.Identity;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.ServicesInterfaces.SSEInterfaces;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.UserServices
{
    public class LogoutService:ILogoutService
    {
        private IGenericRepository<MessengerHub> _messengerHubRepository;
        private IGenericRepository<UserRefreshToken> _refreshTokenRepository;
        private ISendLiveNotificationService _sendLiveNotificationService;

        public LogoutService(IGenericRepository<MessengerHub>messengerHubRepository
            ,ISendLiveNotificationService sendLiveNotificationService,
            IGenericRepository<UserRefreshToken> refreshTokenRepository
            )
        {
            _sendLiveNotificationService = sendLiveNotificationService; 
            _messengerHubRepository = messengerHubRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<ResponseModel<string>> Perform(Guid requestDto)
        {
            try
            {
                await _messengerHubRepository.Delete(requestDto);
                await _refreshTokenRepository.Delete(requestDto);
                await _sendLiveNotificationService.Disconnect(requestDto);
            }
            catch (Exception ex)
            {

            }
            return new ResponseModel<string> { Success = true };
        }
    }
}
