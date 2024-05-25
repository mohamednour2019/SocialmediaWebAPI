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
    public class GetFirendsService : IGetFirendsService
    {
        private IFriendshipRepository _repository;
        private IMapper _mapper;
        public GetFirendsService(IFriendshipRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseModel<List<GetFriendGenericResposneDto>>> Perform(Guid requestDto)
        {
            var friends =await _repository.GetUserFriends(requestDto);
            List<GetFriendGenericResposneDto> response = null;
            if (friends is not null)
            {
               response= _mapper.Map<List<GetFriendGenericResposneDto>>(friends);
            }
            return new ResponseModel<List<GetFriendGenericResposneDto>>()
            {
                Message = null,
                Success = true,
                Data = response
            };
        }
    }
}
