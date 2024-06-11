using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Like.ResponseDTOs;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.LikeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.PostServices.LikeServices
{
    public class GetLikesService : IGetLikesService
    {
        private ILikesRepository _likesRepository;

        public GetLikesService(ILikesRepository likesRepository)
        {
            _likesRepository = likesRepository;
        }

        public async Task<ResponseModel<List<LikeResponseDto>>> Perform(Guid requestDto)
        {
            List<LikeResponseDto> likes = await _likesRepository.getLikes(requestDto);

            return new ResponseModel<List<LikeResponseDto>>()
            {
                Data = likes,
                Message = null,
                Success = true
            };
        }
    }
}
