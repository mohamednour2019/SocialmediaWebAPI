using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.Entities
{
    public class Reply
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        [Required(ErrorMessage = "Can't Add Empty Comment!")]
        [MinLength(1, ErrorMessage = "Can't Add Empty Comment!")]
        public string Content { get; set; }
        public Comment ?Comment { get; set; }
        public Guid ?CommentId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }

        public Guid ?ReplyId { get; set; }
        public Reply? reply {  get; set; }
        public ICollection<Reply>?Replies { get; set; }  

        public ICollection<ReplyLike>? ReplyLikes { get; set;}
    }
}
