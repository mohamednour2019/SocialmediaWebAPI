using SocialMedia.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.ResponseDto_S
{
    public class AddPostResponseDto
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public Guid UserId { get; set; }

        public string ImageUrl {  get; set; }
    }
}
