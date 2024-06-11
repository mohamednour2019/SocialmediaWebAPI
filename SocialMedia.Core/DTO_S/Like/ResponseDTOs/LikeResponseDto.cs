using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.Like.ResponseDTOs
{
    public class LikeResponseDto
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ?UserProfilePictureUrl{ get; set; }
    }
}
