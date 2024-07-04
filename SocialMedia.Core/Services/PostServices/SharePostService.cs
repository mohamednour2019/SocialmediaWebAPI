using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Post.RequestDTOs;
using SocialMedia.Core.DTO_S.Post.ResponseDTOs;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.Services.SSEServices;
using SocialMedia.Core.ServicesInterfaces.NotificatinosInterfaces;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.PostServices
{
    public class SharePostService : ISharePostService
    {
        private IPostRepository _postRepository;
        private IGetNotificationService _notificationService;
        private IGenericRepository<Post> _genericRepository;

        public SharePostService(IPostRepository postRepository
            ,IGetNotificationService getNotificationService
            ,IGenericRepository<Post>genericRepository)
        {
            _genericRepository = genericRepository;
            _notificationService = getNotificationService;
            _postRepository = postRepository;
        }

        public async Task<ResponseModel<SharePostResponseDto>> Perform(SharePostRequestDto requestDto)
        {
            Post sharedPost = new Post()
            {
                SharedFromPostId = requestDto.SharesPostId,
                Id = Guid.NewGuid(),
                Content = requestDto.Thoughts,
                UserId = requestDto.UserId,
                DateTime = DateTime.Now
            };
            SharePostResponseDto response = await _postRepository.SharePost(sharedPost);
            Post MainSharedPost = await _genericRepository.FindAsync(sharedPost.SharedFromPostId);
            if (sharedPost.UserId!= MainSharedPost.UserId)
            {
                var notification = await _notificationService.Perform((Guid)sharedPost.Id);
                await SendLiveNotificationService.SendNotification(notification.Data.UserId, notification);
            }


            return new ResponseModel<SharePostResponseDto>
            {
                Success = true,
                Data = response,
                Message = null
            };
           
        }
    }
}
