using SocialMedia.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.MessegesInterfaces
{
    public interface IDeleteUserConnectionService:IGenericService<Guid,ResponseModel<string>>
    {
    }
}
