using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.Chat.ResponseDTOs
{
    public class GetUserChatResponseDto
    {
        public Guid UserId { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }   
        public string ProfilePictureURL {  get; set; }
        public string LastMessageContent {  get; set; }
        public DateTime LastMessageDate {  get; set; }

    }
}
