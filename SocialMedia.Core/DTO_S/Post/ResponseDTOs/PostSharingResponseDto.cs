using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.Post.ResponseDTOs
{
    public class PostSharingResponseDto
    {
        public Guid? UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string? UserProfilePictureUrl { get; set; }
    }
}
