﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.RequestDto_S
{
    public class AddUserImageRequestDto
    {
        public Guid UserId {  get; set; }
        public IFormFile Image {  get; set; }
    }
}
