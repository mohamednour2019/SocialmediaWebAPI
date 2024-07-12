using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.Reply.ResponseDTOs
{
    public class ReplyResponseDto
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid? CommentId { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public Guid?ParentCommentId { get; set; }
        public bool? isLiked { get; set; }
    }
}
