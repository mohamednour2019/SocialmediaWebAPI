using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;

namespace SocialMedia.Presentation.API.Controllers
{
    public class UserController:BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(ResponseModel<string>))]
        public async Task<IActionResult> addProfilePicture([FromForm]AddUserImageRequestDto requestDto,
            [FromServices] IAddProfilePictureService addProfilePictureService)
            => await  _presenter.Handle(requestDto, addProfilePictureService);
    }
}
