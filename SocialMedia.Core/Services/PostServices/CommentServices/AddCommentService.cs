using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Comment.ResponseDTOs;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.Services.SSEServices;
using SocialMedia.Core.ServicesInterfaces.NotificatinosInterfaces;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces;

namespace SocialMedia.Core.Services.PostServices.CommentServices
{
    public class AddCommentService :IAddCommentService
    {
        private IGetNotificationService _notificationService;
        private IGenericRepository<Comment> _repository;
        private IGenericRepository<User> _userRepository;
        private IGenericRepository<Post> _postRepository;
        private IMapper _mapper;
        public AddCommentService(IMapper mapper,IGenericRepository<Comment>repository,
            IGenericRepository<User> userRepository,IGetNotificationService notificationService
            ,IGenericRepository<Post> postRepository)
        {
            _postRepository= postRepository;
            _notificationService=notificationService;
            _repository=repository;
            _userRepository = userRepository;
            _mapper=mapper;
        }
        public async Task<ResponseModel<CommentResponseDto>> Perform(AddCommentRequestDto requestDto)
        {
            Comment comment=_mapper.Map<Comment>(requestDto);
            User user = await _userRepository.FindAsync(requestDto.UserId);
            comment.User= user;
            comment.Id = Guid.NewGuid();
            comment.DateCreated = DateTime.Now;
            Post post = await _postRepository.FindAsync(requestDto.PostId);
            if (post.UserId != requestDto.UserId)
            {
                comment.NotificationId = Guid.NewGuid();
                try
                {
                    await _repository.AddAsync(comment);
                }
                catch (Exception ex)
                {
                    throw new Exception("Something Went Wrong!");
                }
                try
                {
                    var notification = await _notificationService.Perform((Guid)comment.NotificationId);
                    await SendLiveNotificationService.SendNotification(notification.Data.UserId, notification);
                }
                catch (Exception ex) { }
            }
            else
            {
                try
                {
                    await _repository.AddAsync(comment);
                }
                catch (Exception ex)
                {
                    throw new Exception("Something Went Wrong!");
                }
            }
            CommentResponseDto responseDto = _mapper.Map<CommentResponseDto>(comment);
            return new ResponseModel<CommentResponseDto>()
            {
                Success = true,
                Message = null,
                Data = responseDto
            };
        }
    }
}
