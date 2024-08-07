﻿using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Post.ResponseDTOs;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.RepositoriesInterfaces
{
    public interface IPostRepository
    {
        Task<AddPostResponseDto> AddPost(Post post);
        Task<SharePostResponseDto> SharePost(Post post);
        Task<List<GetUserPostsResponseDto>> GetPostsAsync(Guid userId,int pageNumber,Guid requestedUserId);
        Task<List<GetNewsFeedPostsResponseDto>> GetNewsFeedPostsAsync(Guid userId,int pageNumber);

        Task<GetUserPostsResponseDto> GetPostAsync(Guid postId, Guid userId);
    }
}
