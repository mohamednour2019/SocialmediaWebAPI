using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.Like.RequestDTOs
{
    public class GetLikesRequestDto
    {
        public Guid PostId {  get; set; }
        public int PageNumber { get; set; }
    }
}
