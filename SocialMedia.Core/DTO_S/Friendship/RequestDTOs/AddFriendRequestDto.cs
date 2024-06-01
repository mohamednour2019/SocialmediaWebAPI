using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.RequestDto_S
{
    public class AddFriendRequestDto
    {
        [Required]
        public Guid CurrentUserId { get; set; }
        [Required]
        public Guid FriendId { get; set; }

    }
}
