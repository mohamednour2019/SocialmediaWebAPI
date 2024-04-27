using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTO_S.RequestDto_S
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "You Should Provide Email!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "You Should Provide Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "You Should Provide a Phone Number!")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "User Should Provide FirstName!")]
        [Length(3, 20, ErrorMessage = "Provide a Name with length between 3 and 20 Characters!")]
        public string FirstName { get; set; }


        [Length(3, 20, ErrorMessage = "Provide a Name with length between 3 and 20 Characters!")]
        [Required(ErrorMessage = "User Should Provide FirstName!")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "User Should Provide Birthdate!")]
        public DateOnly BirthDate { get; set; }

        [MaxLength(20)]
        public string? Relationship { get; set; }
    }
}
