using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.Entities
{
    public class OTP
    {
        public Guid Id { get; set; }
        public Guid UserId {  get; set; }
        public string OTPCode { get; set; }
        public User User { get; set; }
        public DateTime Expiration { get; set; }
    }
}
