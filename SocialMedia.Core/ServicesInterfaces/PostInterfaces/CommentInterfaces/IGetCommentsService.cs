using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Comment.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces
{
    public interface IGetCommentsService:IGenericService<Guid,ResponseModel<List<GetCommentResponseDto>>>
    {
    }
}
