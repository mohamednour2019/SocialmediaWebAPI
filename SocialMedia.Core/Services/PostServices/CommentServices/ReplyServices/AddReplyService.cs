using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Comment.ResponseDTOs;
using SocialMedia.Core.DTO_S.Reply.RequestDTOs;
using SocialMedia.Core.DTO_S.Reply.ResponseDTOs;
using SocialMedia.Core.Services.SSEServices;
using SocialMedia.Core.ServicesInterfaces.NotificatinosInterfaces;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces.ReplyInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.PostServices.CommentServices.ReplyServices
{
    public class AddReplyService : IAddReplyService
    {
        private ICommentRepository _commentRepository;
        private IGetNotificationService _notificationService;

        public AddReplyService(ICommentRepository commentRepository
            ,IGetNotificationService getNotificationService)
        {
            _commentRepository = commentRepository;
            _notificationService = getNotificationService;
        }

        public async Task<ResponseModel<GetCommentResponseDto>> Perform(AddReplyRequestDto requestDto)
        {
            Comment reply = new Comment()
            {
                Id = Guid.NewGuid(),
                Content = requestDto.Content,
                CommentParentId = requestDto.CommentParentId,
                UserId = requestDto.UserId,
                PostId = requestDto.PostId,
                DateCreated = DateTime.Now,
                
            };
            GetCommentResponseDto response;

            try
            {
                response = await _commentRepository.AddReplyAsync(reply);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            try
            {
                var notification = await _notificationService.Perform((Guid)reply.Id);
                await SendLiveNotificationService.SendNotification(notification.Data.UserId, notification);
            }
            catch(Exception ex)
            {

            }

            return new ResponseModel<GetCommentResponseDto>
            {
                Data = response,
                Message = null,
                Success = true
            };
        }
    }
}
