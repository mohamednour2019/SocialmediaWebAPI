using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Like.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.PostInterfaces.LikeInterfaces
{
    public interface IGetLikesService:IGenericService<Guid,ResponseModel<List<LikeResponseDto>>>
    {
    }
}
