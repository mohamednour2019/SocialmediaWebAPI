using SocialMedia.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.ResponseDto_S
{
    public class SignInResponseDto
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? Relationship { get; set; }

        public string Gender {  get; set; }
        public List<Post> Posts { get; set; }
        public List<FriendsRelationship> FirstUserFriends { get; set; }
    }
}
