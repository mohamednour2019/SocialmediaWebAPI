using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.Entities
{
    public class Like
    {
        public User User { get; set; }
        public Guid UserId { get; set; }

        public Guid NotificationId { get; set; }
        public Post Post { get; set; }
        public Guid PostId {  get; set; }
    }
}
