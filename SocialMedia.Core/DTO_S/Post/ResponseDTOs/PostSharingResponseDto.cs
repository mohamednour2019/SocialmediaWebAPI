using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.Post.ResponseDTOs
{
    public class PostSharingResponseDto
    {
        public Guid PostId { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public string? PostImageUrl { get; set; }
        public Guid? UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string? UserProfilePictureUrl { get; set; }
    }
}
