using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.Entities
{
    public class UserRefreshToken
    {
        public Guid UserId {  get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresIn {  get; set; }
        public User User { get; set; }
    }
}
