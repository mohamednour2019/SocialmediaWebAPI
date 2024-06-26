﻿using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;


namespace SocialMedia.Core.ServicesInterfaces.PostInterfaces
{
    public interface IDeletePostService:IGenericService<DeletePostRequestDto
        ,ResponseModel<DeletePostResponseDto>>
    {
    }
}
