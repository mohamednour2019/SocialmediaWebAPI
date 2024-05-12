using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Core.Domain.Entities
{
    public class User: IdentityUser<Guid>
    {

        [Required(ErrorMessage ="User Should Provide FirstName!")]
        [Length(3,20,ErrorMessage ="Provide a Name with length between 3 and 20 Characters!")]
        public string FirstName {  get; set; }


        [Length(3, 20, ErrorMessage = "Provide a Name with length between 3 and 20 Characters!")]
        [Required(ErrorMessage = "User Should Provide FirstName!")]
        public string LastName { get; set; }    


        [Required(ErrorMessage ="User Should Provide Birthdate!")]
        public DateOnly BirthDate {  get; set; }

        public string Gender {  get; set; }

        public string? Education { get; set; }

        public string? Work {  get; set; }

        public byte[]? ProfilePicture { get; set; }

        [MaxLength(20)]
        public string? Relationship {  get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Like>? Like { get; set; }
        public ICollection<FriendsRelationship>? FirstUserFriends {  get; set; }
        public ICollection<FriendsRelationship>? SecondUserFriends { get; set; }
        public ICollection<Message>? SenderMessages { get; set;}
        public ICollection<Message>? ReciverMessages {  get; set; }
        public ICollection<Notification>? Notifications { get; set; }
        public string OTP { get; set; }
        public DateTime OtpExpiration { get; set; }

    }
}
