using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.Comment.RequestDTOs
{
    public class GetCommentsRequestDto
    {
        public Guid PostId {  get; set; }

        public Guid UserId { get; set; }
        public int PageNumber {  get; set; }
    }
}
