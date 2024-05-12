using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces
{
    public interface IAddSelfRelationFriendshipService
    {
        Task AddSelfRlation(Guid UserId);
    }
}
