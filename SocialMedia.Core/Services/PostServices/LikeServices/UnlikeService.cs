using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Like.ResponseDTOs;
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
    public  class UnlikeService:IUnlikeService
    {
        private IMapper _mapper;
        private IGenericRepository<Like> _repository;
        public UnlikeService(IMapper mapper, IGenericRepository<Like> repository)
        {
            _repository=repository;
            _mapper=mapper;
        }

        public async Task<ResponseModel<LikeResponseDto>> Perform(UnlikeRequestDto requestDto)
        {
            try
            {
                await _repository.Delete(requestDto.UserId,requestDto.PostId);
            }catch(Exception ex)
            {
                throw new Exception("Something Went Wrong!");
            }

            return new ResponseModel<LikeResponseDto>() { Success = true };
        }
    }
}
