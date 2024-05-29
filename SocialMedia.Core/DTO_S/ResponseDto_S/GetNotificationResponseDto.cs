using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.ResponseDto_S
{
    public class GetNotificationResponseDto
    {
        public Guid Id { get; set; }
        public DateTime? DateTime { get; set; }
        public NotificationType? NotificationType { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public Guid? PostId { get; set; }
        public string? EmmiterName { get; set; }
        public Guid UserId { get; set; }
    }
}
