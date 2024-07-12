using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        [Required(ErrorMessage = "Can't Add Empty Comment!")]
        [MinLength(1, ErrorMessage = "Can't Add Empty Comment!")]
        public string Content { get; set; }
        public Post Post { get; set; }
        public Guid PostId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public ICollection<Comment>? Replies { get; set; }
        public Comment comment { get; set; }
        public Guid? CommentParentId{ get; set; }
        public ICollection<CommentLike>? Likes { get; set; }
    }
}
