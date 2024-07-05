using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.Chat.RequestDTOs
{
    public class GetUserChatRequestDto
    {
        public Guid UserId { get; set; }
        public int PageNumber {  get; set; }
    }
}
