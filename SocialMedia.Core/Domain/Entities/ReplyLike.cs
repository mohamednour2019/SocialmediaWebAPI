using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.Entities
{
    public class ReplyLike
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Reply Reply { get; set; }
        public Guid ReplyId { get; set; }
    }
}
