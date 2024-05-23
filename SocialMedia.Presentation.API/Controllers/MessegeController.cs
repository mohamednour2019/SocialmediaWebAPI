using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.MessegesInterfaces;

namespace SocialMedia.Presentation.API.Controllers
{
    public class MessegeController:BaseController
    {
        [HttpGet("{firstUserId}/{secondUserId}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(ResponseModel<List<GetChatMessegesResponseDto>>))]
        public async Task<IActionResult> GetChatMesseges(Guid firstUserId,Guid secondUserId
            , [FromServices] IGetChatMessegesService getChatMessegesService)
            =>await _presenter.Handle(new GetChatMessegesRequestDto() 
            { FirstUserId=firstUserId,SedondUserId=secondUserId}, getChatMessegesService);    
    }
}
