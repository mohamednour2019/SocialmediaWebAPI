using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.InputDto_s
{
    public class AddMessegeInputDto
    {
        public Guid SenderId {  get; set; }
        public Guid RecieverId { get; set; }
        public string Messege {  get; set; }
    }
}
