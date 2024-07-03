using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Post.RequestDTOs;
using SocialMedia.Core.DTO_S.Post.ResponseDTOs;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.PostInterfaces
{
    public interface ISharePostService:IGenericService<SharePostRequestDto,ResponseModel<SharePostResponseDto>>
    {

    }
}
