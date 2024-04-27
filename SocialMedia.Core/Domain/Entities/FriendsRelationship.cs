using Microsoft.Identity.Client;
using SocialMedia.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.Entities
{
    public class FriendsRelationship
    {
        public User FirstUser { get; set; }
        public Guid FirstUserId { get; set; }
        public User SecondUser { get; set; }
        public Guid SecondUserId {  get; set; }
        [MaxLength(15)]
        public FriendshipStatus ? Type {  get; set; }
    }
}
