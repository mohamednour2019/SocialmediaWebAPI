using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;


namespace SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces
{
    public interface IAddFriendService:IGenericService<AddFriendRequestDto
        , ResponseModel<AddFriendResponseDto>>
    {
    }
}
