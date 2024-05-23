using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.InputDto_s;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.MessegesInterfaces;

namespace SocialMedia.Core.Services.MessegesServices
{
    public class AddMessegeService : IAddMessageService
    {
        private IMapper _mapper;
        private IMessegesRepository _messageRepository;
        public AddMessegeService(IMessegesRepository messageRepository,IMapper mapper)
        {
            _messageRepository= messageRepository;
            _mapper=mapper;
        }
        public async Task<GetChatMessegesResponseDto> AddMessage(AddMessegeInputDto inputDto)
        {
            Message message = new Message()
            {
                SenderId = inputDto.SenderId,
                ReciverId = inputDto.RecieverId,
                Content = inputDto.Messege,
                CreatedDate = DateTime.Now,
                Id = Guid.NewGuid()
            };
           try {
                await _messageRepository.AddMessgeAsync(message);
            }catch (Exception ex) {
                throw new Exception();
           }
            var newMessage=_mapper.Map<GetChatMessegesResponseDto>(message);
            return newMessage;

        }
    }
}
