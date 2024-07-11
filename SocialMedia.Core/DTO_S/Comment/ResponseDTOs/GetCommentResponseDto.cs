using SocialMedia.Core.DTO_S.Reply.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.Comment.ResponseDTOs
{
    public class GetCommentResponseDto
    {
        public Guid CommentId {  get; set; }

        public DateTime DateCreated { get; set; }
        public string Content {  get; set; }

        public Guid PostId {  get; set; }
        public Guid UserId {  get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string ? ProfilePictureUrl {  get; set; }

        public List<AddReplyResponseDto> Replies { get; set; }
        public int RepliesCount {  get; set; }
    }
}
