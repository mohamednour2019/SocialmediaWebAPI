using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.RequestDto_S
{
    public class UpdateOtpRequestDto
    {
        [Required(ErrorMessage = "you should provide user id")]
        public Guid UserId { get; set; }
    }
}
