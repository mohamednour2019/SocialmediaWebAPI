using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.Entities
{
    public class MessengerHub
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string ConnectionId {  get; set; }
    }
}
