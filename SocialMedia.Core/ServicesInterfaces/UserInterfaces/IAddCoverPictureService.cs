using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.UserInterfaces
{
    public interface IAddCoverPictureService:IGenericService<AddUserImageRequestDto,ResponseModel<string>>
    {
    }
}
