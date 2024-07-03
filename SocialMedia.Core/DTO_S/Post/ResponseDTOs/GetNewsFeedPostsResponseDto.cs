using SocialMedia.Core.DTO_S.Post.ResponseDTOs;

namespace SocialMedia.Core.DTO_S.ResponseDto_S
{
    public class GetNewsFeedPostsResponseDto
    {
        public Guid PostId { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public string? PostImageUrl { get; set; }
        public Guid? UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string? UserProfilePictureUrl { get; set; }
        public int LikesCount {  get; set; }
        public int CommentsCount {  get; set; }
        public bool isLiked {  get; set; }
        public PostSharingResponseDto? PostSharingData { get; set; }

    }
}
