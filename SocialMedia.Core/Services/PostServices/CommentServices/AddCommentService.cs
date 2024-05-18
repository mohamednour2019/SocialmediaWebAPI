using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces;

namespace SocialMedia.Core.Services.PostServices.CommentServices
{
    public class AddCommentService :IAddCommentService
    {
        private IGenericRepository<Comment> _repository;
        private IGenericRepository<User> _userRepository;
        private IMapper _mapper;
        public AddCommentService(IMapper mapper,IGenericRepository<Comment>repository,
            IGenericRepository<User> userRepository)
        {
            _repository=repository;
            _userRepository = userRepository;
            _mapper=mapper;
        }
        public async Task<ResponseModel<AddCommentResponseDto>> Perform(AddCommentRequestDto requestDto)
        {
            Comment comment=_mapper.Map<Comment>(requestDto);
            User user = await _userRepository.FindAsync(requestDto.UserId);
            comment.User= user;
            comment.Id = Guid.NewGuid();
            comment.NotificationId=Guid.NewGuid();
            comment.DateCreated = DateTime.Now;
            try
            {
                await _repository.AddAsync(comment);
            }catch (Exception ex)
            {
                throw new Exception("Something Went Wrong!");
            }
            AddCommentResponseDto responseDto = _mapper.Map<AddCommentResponseDto>(comment);
            return new ResponseModel<AddCommentResponseDto>()
            {
                Success = true,
                Message = null,
                Data = responseDto
            };
        }
    }
}
