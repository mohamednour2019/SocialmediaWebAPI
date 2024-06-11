using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.Token.RequestDTOs
{
    public class RefreshTokenRequestDto
    {
        public Guid UserId {  get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
