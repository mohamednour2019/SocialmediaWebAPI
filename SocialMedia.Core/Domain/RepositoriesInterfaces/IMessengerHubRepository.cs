using SocialMedia.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.RepositoriesInterfaces
{
    public interface IMessengerHubRepository
    {
        Task AddConnectionAsync(MessengerHub userConnection);
        Task DeleteConnectionAsync(Guid userId);
        Task<MessengerHub> GetConnectionAsync(Guid userId);
        Task DeleteUserConnection(Guid userId);
    }
}
