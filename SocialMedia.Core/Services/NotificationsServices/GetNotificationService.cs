using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.NotificatinosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.NotificationsServices
{
    public class GetNotificationService : IGetNotificationService
    {
        private IGenericRepository<Notification> _repository;
        private IMapper _mapper;
        public GetNotificationService(IGenericRepository<Notification> repository,
            IMapper mapper) {
            _repository= repository;
            _mapper= mapper;
        }

        public async Task<ResponseModel<GetNotificationResponseDto>> Perform(Guid requestDto)
        {
            Notification notification = await _repository.FindAsync(requestDto);
            GetNotificationResponseDto response = _mapper.Map<GetNotificationResponseDto>(notification);
            return new ResponseModel<GetNotificationResponseDto>()
            {
                Success = true,
                Message = null,
                Data = response
            };
        }
    }
}
