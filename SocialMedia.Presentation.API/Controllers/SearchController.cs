using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;

namespace SocialMedia.Presentation.API.Controllers
{
    public class SearchController:BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK,Type= typeof(ResponseModel<List<SearchUserResponseDto>>))]
        public async Task<IActionResult> searchUser(SearchUserRequestDto requestDto
            , [FromServices]ISearchUserService searchUserService)
            =>await _presenter.Handle(requestDto,searchUserService);  

    }
}
