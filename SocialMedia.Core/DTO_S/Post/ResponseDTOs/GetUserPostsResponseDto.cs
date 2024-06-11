using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Comment.ResponseDTOs;
using SocialMedia.Core.DTO_S.Like.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.ResponseDto_S
{
    public class GetUserPostsResponseDto
    {
        public Guid PostId { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public string? PostImageUrl { get; set; }
        public Guid? UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string? UserProfilePictureUrl { get; set; }
        public int LikesCount { get; set; }

        public int CommentsCount { get; set; }
        public bool isLiked { get; set; }
    }
}
