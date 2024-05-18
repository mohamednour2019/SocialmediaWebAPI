using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.InputDto_s
{
    public class AddNotificationInputDto
    {
        public User EmmiterUser  { get; set; }
        public Guid PostId { get; set; }
        public NotificationType NotificationType { get; set; }

    }
}
