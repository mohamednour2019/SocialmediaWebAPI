using Microsoft.AspNetCore.Identity;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
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

        public LogoutService(IGenericRepository<MessengerHub>messengerHubRepository)
        {
            _messengerHubRepository = messengerHubRepository;
        }

        public async Task<ResponseModel<string>> Perform(Guid requestDto)
        {
            await _messengerHubRepository.Delete(requestDto);
            return new ResponseModel<string> { Success = true };
        }
    }
}
