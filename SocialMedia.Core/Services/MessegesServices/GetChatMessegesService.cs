using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.MessegesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.MessegesServices
{
    public class GetChatMessegesService : IGetChatMessegesService
    {
        private IMessegesRepository _messegesRepository;
        private IMapper _mapper;
        public GetChatMessegesService(IMessegesRepository messegesRepository,IMapper mapper)
        {
            _messegesRepository = messegesRepository;
            _mapper = mapper;
        }
        public async Task<ResponseModel<List<GetChatMessegesResponseDto>>> Perform(GetChatMessegesRequestDto requestDto)
        {
            List<Message> chatMesseges=await _messegesRepository.GetMessagesAsync(requestDto);
            List<GetChatMessegesResponseDto> response = _mapper.Map<List<GetChatMessegesResponseDto>>(chatMesseges);
            return new ResponseModel<List<GetChatMessegesResponseDto>>
            {
                Success = true,
                Data = response,
                Message = null
            };
           
        }
    }
}
