using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;

namespace SocialMedia.Core.Services.FriendshipServices
{
    public class AcceptFriendRequestService : GenericService<FriendsRelationship>, IAcceptFriendRequestService
    {
        private IUnitOfWork _unitOfWork;
        public AcceptFriendRequestService(IMapper mapper
            ,IGenericRepository<FriendsRelationship>repository,IUnitOfWork unitOfWork)
            :base(mapper,repository)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseModel<AcceptFirendRequestReaponseDto>> Perform(AcceptFriendRequestRequestDto requestDto)
        {
            FriendsRelationship Friendship= await _repository
                .FindAsync(requestDto.SenderId, requestDto.ReciverId);
            if(Friendship is not null&&Friendship.Type == FriendshipStatus.FriendRequest) {

                Friendship.Type = FriendshipStatus.Friends;
                FriendsRelationship firend = new FriendsRelationship()
                {
                    SecondUserId = requestDto.SenderId,
                    FirstUserId = requestDto.ReciverId,
                    Type = FriendshipStatus.Friends

                };
                await _repository.AddAsync(firend);
                await _unitOfWork.SaveChangeAsync();
            }
            else
            {
                throw new Exception("This Friend Request No Longer Available!");
            }


            return new ResponseModel<AcceptFirendRequestReaponseDto>()
            {
                Data = null,
                Message = new List<string>() { "friend has been added to your Friends List" },
                Success = true
            };
        }
    }
}
