using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.RequestDto_S
{
    public class SignInRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool StaySignIn { get; set; } = false;
    }
}
