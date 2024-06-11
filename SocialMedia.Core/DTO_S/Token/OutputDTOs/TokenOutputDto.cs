using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.Token.OutputDTOs
{
    public class TokenOutputDto
    {
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
