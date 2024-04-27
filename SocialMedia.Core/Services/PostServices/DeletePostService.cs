using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.PostServices
{
    public class DeletePostService : GenericService<Post>, IDeletePostService
    {
        public DeletePostService(IMapper mapper,IGenericRepository<Post>repository)
            :base(mapper,repository)
        {
            
        }
        public async Task<DeletePostResponseDto> Perform(DeletePostRequestDto requestDto)
        {
           await _repository.Delete(requestDto.PostId);
           return new DeletePostResponseDto() { PostId = requestDto.PostId };
        }
    }
}
