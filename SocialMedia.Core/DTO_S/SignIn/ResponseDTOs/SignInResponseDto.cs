﻿using SocialMedia.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
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

        public string? Education { get; set; }

        public string Token {  get; set; }
        public string RefreshToken {  get; set; }
        public DateTime ExpiresIn {  get; set; }
        public string? Work { get; set; }

        public string? ProfilePictureUrl { get; set; }
        public string? CoverPictureUrl { get; set; }
    }
}
