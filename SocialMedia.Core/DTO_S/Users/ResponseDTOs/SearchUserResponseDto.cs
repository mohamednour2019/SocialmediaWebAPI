using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.ResponseDto_S
{
    public class SearchUserResponseDto
    {
        public Guid UserId { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }


    }
}
