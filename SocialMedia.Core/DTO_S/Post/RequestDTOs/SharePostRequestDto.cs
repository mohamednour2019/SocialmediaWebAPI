using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.Post.RequestDTOs
{
    public class SharePostRequestDto
    {
        public Guid UserId {  get; set; }
        public Guid SharesPostId { get; set; }

        public string? Thoughts {  get; set; }
    }
}
