using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.ResponseDto_S
{
    public class GenerateOtpResponseDto
    {
        public string OTP {  get; set; }
        public DateTime ExpireyDate {  get; set; }
    }
}
