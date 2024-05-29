using Microsoft.Identity.Client;
using SocialMedia.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public DateTime? DateTime { get; set; }
        public NotificationType? NotificationType { get; set; }
        public Guid? PostId {  get; set; }
        public string? NotificationImage {  get; set; }
        public string? EmmiterName {  get; set; }
        public Guid? EmmiterId {  get; set; }
        public User User { get; set; }  
        public Guid UserId {  get; set; }
    }
}
