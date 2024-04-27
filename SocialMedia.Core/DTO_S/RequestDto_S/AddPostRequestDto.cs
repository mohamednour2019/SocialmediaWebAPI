using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.RequestDto_S
{
    public class AddPostRequestDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Post Should Have Content!")]
        public string Content { get; set; }
    }
}
