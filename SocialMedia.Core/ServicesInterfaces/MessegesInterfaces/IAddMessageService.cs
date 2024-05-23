using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.InputDto_s;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.ServicesInterfaces.MessegesInterfaces
{
    public interface IAddMessageService
    {
        Task<GetChatMessegesResponseDto> AddMessage(AddMessegeInputDto inputDto);
    }
}
