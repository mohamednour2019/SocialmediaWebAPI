using SocialMedia.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.ResponseDto_S
{
    public class AddCommentResponseDto
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}
