using SocialMedia.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.RequestDto_S
{
    public class GetFriendGenericRequestDto
    {
        public Guid UserId { get; set; }
        public FriendshipStatus Status { get; set; }

        public string Message {  get; set; }
    }
}
