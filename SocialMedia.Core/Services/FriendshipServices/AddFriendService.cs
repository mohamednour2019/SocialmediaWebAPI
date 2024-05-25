using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using SocialMedia.SharedKernel.CustomExceptions;


namespace SocialMedia.Core.Services.FriendshipServices
{
    public class AddFriendService :IAddFriendService
    {
        private IMapper _mapper;
        private IGenericRepository<FriendsRelationship> _repository;
        public AddFriendService(IMapper mapper
            ,IGenericRepository<FriendsRelationship>repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ResponseModel<AddFriendResponseDto>> Perform(AddFriendRequestDto requestDto)
        {
            FriendsRelationship friendRequest = _mapper.Map<FriendsRelationship>(requestDto);
            friendRequest.Type = FriendshipStatus.FriendRequest;
            try
            {
                await _repository.AddAsync(friendRequest);
            }catch(Exception ex)
            {
                throw new ViolenceValidationException("Friend Request Already Sent!");
            }

            return new ResponseModel<AddFriendResponseDto>();

        }
    }
}
