using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.Entities
{
    public class CommentLike
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Comment Comment { get; set; }    
        public Guid CommentId {  get; set; }
    }
}
