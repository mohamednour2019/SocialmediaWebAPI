using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.Entities
{
    [NotMapped]
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public List<string>? Message { get; set; }
        public T? Data { get; set; }

    }
}
