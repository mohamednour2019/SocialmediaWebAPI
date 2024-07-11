using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Reply.RequestDTOs;
using SocialMedia.Core.DTO_S.Reply.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces.ReplyInterfaces
{
    public interface IAddReplyService:IGenericService<AddReplyRequestDto,ResponseModel<AddReplyResponseDto>>
    {
    }
}
