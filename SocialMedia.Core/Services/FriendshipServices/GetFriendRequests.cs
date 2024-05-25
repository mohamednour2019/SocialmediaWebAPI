using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.FriendshipServices
{
    public class GetFriendRequests : IGetFriendRequests
    {
        private IFriendshipRepository _repository;
        private IMapper _mapper;
        public GetFriendRequests(IFriendshipRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseModel<List<GetFriendGenericResposneDto>>> Perform(Guid requestDto)
        {
            List<User> requests=await _repository.GetFriendRequests(requestDto);
            List<GetFriendGenericResposneDto> response=null;
            if (requests is not null)
            {
                response = _mapper.Map<List<GetFriendGenericResposneDto>>(requests);
            }

            return new ResponseModel<List<GetFriendGenericResposneDto>>()
            {
                Success = true,
                Message = null,
                Data = response
            };

        }
    }
}
