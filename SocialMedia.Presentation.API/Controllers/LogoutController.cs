using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;

namespace SocialMedia.Presentation.API.Controllers
{
    public class LogoutController:BaseController
    {
        [HttpPost("{userId}")]
        public async Task<IActionResult> Logout(Guid userId, [FromServices]ILogoutService logoutService)
            =>await _presenter.Handle(userId, logoutService); 
    }
}
