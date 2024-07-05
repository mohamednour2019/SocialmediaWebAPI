using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Chat.RequestDTOs;
using SocialMedia.Core.DTO_S.Chat.ResponseDTOs;
using SocialMedia.Core.ServicesInterfaces.MessegesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.MessegesServices
{
    public class GetUserChatsService : IGetUserChatsService
    {
        private IChatRepository _chatRepository;

        public GetUserChatsService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<ResponseModel<List<GetUserChatResponseDto>>> Perform(GetUserChatRequestDto requestDto)
        {
            List<GetUserChatResponseDto>response= await _chatRepository.GetUserChats(requestDto.UserId, requestDto.PageNumber);
            return new ResponseModel<List<GetUserChatResponseDto>>() 
            { 
               Data=response,
               Success=true,
               Message=null
            };
        }
    }
}
