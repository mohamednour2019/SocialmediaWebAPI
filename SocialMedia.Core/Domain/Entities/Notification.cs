using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.Entities
{
    public class Notification
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [Length(0,50)]
        public string Title { get; set; }
        [Required]
        [Length(0, 500)]
        public string Description { get; set; }
        public User User { get; set; }  
        public Guid UserId {  get; set; }
    }
}
