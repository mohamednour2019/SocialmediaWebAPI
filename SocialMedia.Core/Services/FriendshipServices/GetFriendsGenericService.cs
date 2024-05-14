using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using SocialMedia.SharedKernel.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.FriendshipServices
{
    public class GetFriendsGenericService : IGetFriendsGenericService
    {
        private IFriendshipRepository _repository;
        private IMapper _mapper;
        public GetFriendsGenericService(IFriendshipRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseModel<List<GetFriendGenericResposneDto>>> Perform(GetFriendGenericRequestDto requestDto)
        {
            var friends =await _repository.GetFriendWithType(requestDto.UserId, requestDto.Status);
            var response = new ResponseModel<List<GetFriendGenericResposneDto>>();
            if (friends is null)
            {
                response.Success = true;
                response.Data = null;
                response.Message = new List<string>() { $"you don't have {requestDto.Message} yet!" };
            }
            else
            {
                List<GetFriendGenericResposneDto> responseData=_mapper.Map<List<GetFriendGenericResposneDto>>(friends);
                response.Success = true;
                response.Data = responseData;
                response.Message = null;
            }
            return response;
        }
    }
}
