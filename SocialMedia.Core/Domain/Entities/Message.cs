using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content {  get; set; }
        public User Sender { get; set; }
        public Guid SenderId { get; set; }
        public User Reciver { get; set; }
        public Guid ReciverId { get; set; }
    }
}
