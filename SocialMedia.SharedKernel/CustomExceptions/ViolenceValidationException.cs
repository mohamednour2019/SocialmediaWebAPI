using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.SharedKernel.CustomExceptions
{
    public class ViolenceValidationException:Exception
    {
        public ViolenceValidationException() { }
        public ViolenceValidationException(string errorMessage):base(errorMessage) { }
    }
}
