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
    public class AddLikeService : GenericService<Like>, IAddLikeService
    {
        public AddLikeService(IMapper mapper,IGenericRepository<Like>repository)
            :base(mapper,repository)
        {
            
        }
        public async Task<AddLikeResponseDto> Perform(AddLikeRequestDto requestDto)
        {
            Like like = _mapper.Map<Like>(requestDto);
            try
            {
                await _repository.AddAsync(like);
            }catch(Exception ex)
            {
                throw new Exception("Something Went Wrong!");
            }

            return new AddLikeResponseDto();
        }
    }
}
