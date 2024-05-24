using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.RequestDto_S
{
    public class GetUserRequestDto
    {
        public Guid CurrentUserId { get; set; }
        public Guid RequestedUserId { get; set; }
    }
}
