namespace SocialMedia.Core.Domain.Entities
{
    public class Chat
    {
        public User FirstUser { get; set; }
        public Guid FirstUserId { get; set; }
        public User SecondUser { get; set; }
        public Guid SecondUserId {  get; set; }
        public Guid LastMessegeId {  get; set; }
        public Message Message { get; set; }
    }
}
