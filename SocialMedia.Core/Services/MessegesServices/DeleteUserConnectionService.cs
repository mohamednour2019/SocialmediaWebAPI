using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.ServicesInterfaces.MessegesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.MessegesServices
{
    public class DeleteUserConnectionService : IDeleteUserConnectionService
    {
        private IMessengerHubRepository _messengerHubRepository;

        public DeleteUserConnectionService(IMessengerHubRepository messengerHubRepository)
        {
            _messengerHubRepository = messengerHubRepository;
        }

        public async Task<ResponseModel<string>> Perform(Guid requestDto)
        {
            await _messengerHubRepository.DeleteUserConnection(requestDto);
            return new ResponseModel<string>()
            {
                Success = true,
                Data = null,
                Message = null
            };
        }
    }
}
