using SocialMedia.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.RequestDto_S
{
    public class AddCommentRequestDto
    {
        public string Content { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}
