using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.InputDto_s;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.HubInterfaces;
using SocialMedia.Core.ServicesInterfaces.MessegesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.HubServices
{
    public class MessengerHubService :Hub, IMessengerHubService
    {
        private IHttpContextAccessor _contextAccessor;
        private IMessengerHubRepository _messengerHubRepository;
        private IAddMessageService _addMessageService;
        public MessengerHubService(IHttpContextAccessor contextAccessor
            , IMessengerHubRepository messengerHubRepository,
            IAddMessageService addMessageService)
        {
            _addMessageService = addMessageService;
            _contextAccessor = contextAccessor;
            _messengerHubRepository = messengerHubRepository;
        }
        public override async Task OnConnectedAsync()
        {
            var HttpContext = _contextAccessor.HttpContext;
            Guid userId =Guid.Parse(HttpContext.Request.Query["userId"].ToString());
            string connectionId = Context.ConnectionId;
            MessengerHub newConnection = new MessengerHub()
            {
                ConnectionId = connectionId,
                UserId = userId
            };
            try
            {
                await _messengerHubRepository.AddConnectionAsync(newConnection);
            }catch(Exception ex) {}     
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var HttpContext = _contextAccessor.HttpContext;
            Guid userId = Guid.Parse(HttpContext.Request.Query["userId"].ToString());
            await _messengerHubRepository.DeleteConnectionAsync(userId);
        }
        public async Task<string> SendMessage(Guid recieverId,Guid senderId,string message)
        {
            MessengerHub recieverConnection= await _messengerHubRepository.GetConnectionAsync(recieverId);
            AddMessegeInputDto inputDto = new AddMessegeInputDto()
            { SenderId = senderId, RecieverId = recieverId, Messege = message };
            GetChatMessegesResponseDto addedMessage =await _addMessageService.AddMessage(inputDto);
            var response = JsonSerializer.Serialize(addedMessage);
            if (recieverConnection is not null)
            {
                await Clients.Client(recieverConnection.ConnectionId).SendAsync("lisetnMesseges", response);
            }
            return response;    

        }
    }
}
