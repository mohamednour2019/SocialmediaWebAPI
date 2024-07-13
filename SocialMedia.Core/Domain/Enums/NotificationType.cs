using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.Enums
{
    public enum NotificationType{
        Like=0,
        Comment=1,
        Share=2,
        FriendRequest=3,
        FriendRequestAccepted=4,
        Reply=5
    }
}
