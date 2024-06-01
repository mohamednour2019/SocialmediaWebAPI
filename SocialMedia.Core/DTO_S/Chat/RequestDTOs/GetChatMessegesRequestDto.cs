using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.RequestDto_S
{
    public class GetChatMessegesRequestDto
    {
        public Guid FirstUserId { get; set; }
        public Guid SedondUserId { get; set; }
    }
}
