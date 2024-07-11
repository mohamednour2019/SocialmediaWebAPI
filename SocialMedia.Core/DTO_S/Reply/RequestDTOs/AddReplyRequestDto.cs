using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.Reply.RequestDTOs
{
    public class AddReplyRequestDto
    {
        public Guid UserId {  get; set; }
        public string Content {  get; set; }
        public Guid CommentId { get; set; }
        public Guid ? ReplyId { get; set; }
    }
}
