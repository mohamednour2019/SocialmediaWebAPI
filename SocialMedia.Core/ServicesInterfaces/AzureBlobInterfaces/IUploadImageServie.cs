using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.AzureBlobInterfaces
{
    public interface IUploadImageServie
    {
        Task<string> UploadImage(IFormFile image);
    }
}
