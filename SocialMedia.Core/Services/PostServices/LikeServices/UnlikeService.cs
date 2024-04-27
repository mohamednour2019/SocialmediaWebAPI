using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.LikeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.PostServices.LikeServices
{
    public  class UnlikeService:GenericService<Like>,IUnlikeService
    {
        public UnlikeService(IMapper mapper, IGenericRepository<Like> repository)
            : base(mapper, repository)
        {

        }

        public async Task<UnlikeResponseDto> Perform(UnlikeRequestDto requestDto)
        {
            try
            {
                await _repository.Delete(requestDto.UserId,requestDto.PostId);
            }catch(Exception ex)
            {
                throw new Exception("Something Went Wrong!");
            }

            return new UnlikeResponseDto();
        }
    }
}
