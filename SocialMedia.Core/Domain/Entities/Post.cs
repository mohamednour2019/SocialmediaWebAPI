using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.Entities
{
    public class Post
    {
        [Required(ErrorMessage ="Post Should Have Id!")]
        public Guid Id { get; set; }
        public string Content {  get; set; }

        [Required(ErrorMessage ="Post Should Have Date and Time of Creation!")]
        public DateTime DateTime { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public string? ImageUrl {  get; set; }
        public Guid? SharedFromPostId { get; set; }
        public Post? SharedPost { get; set; }
        public ICollection<Post>?SharedPosts { get; set; }
        public ICollection<Comment>?Comments { get; set; }
        public ICollection<Like>?Likes { get; set; }

    }
}
