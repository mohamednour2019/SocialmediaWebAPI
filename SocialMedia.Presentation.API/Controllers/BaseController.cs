using Microsoft.AspNetCore.Mvc;
using SocialMedia.Presentation.API.ControllerPresenter;

namespace SocialMedia.Presentation.API.Controllers
{
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class BaseController:ControllerBase
    {
        protected Presenter _presenter;
        protected ContentResult Response {  get; set; }
        public BaseController()
        {
            _presenter = new Presenter();
            Response = new ContentResult() { ContentType= "application/json" };
        }
    }
}
