using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Chat.RequestDTOs;
using SocialMedia.Core.DTO_S.Chat.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.MessegesInterfaces
{
    public interface IGetUserChatsService:IGenericService<GetUserChatRequestDto,ResponseModel<List<GetUserChatResponseDto>>>
    {
    }
}
