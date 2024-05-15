using AutoMapper;
using Microsoft.Data.SqlClient;
using SendGrid.Helpers.Mail;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.DTO_S.ResponseDto_S;


namespace SocialMedia.Infrastructure.Mapper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            Initialize();
        }
        public void Initialize()
        {
            CreateMap<RegisterRequestDto, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));

            CreateMap<User, SignInResponseDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Relationship, opt => opt.MapFrom(src => src.Relationship))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Work, opt => opt.MapFrom(src => src.Work))
                .ForMember(dest => dest.Education, opt => opt.MapFrom(src => src.Education))
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture));


            CreateMap<User, GetFriendGenericResposneDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            .ForMember(dest => dest.Relationship, opt => opt.MapFrom(src => src.Relationship))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Work, opt => opt.MapFrom(src => src.Work))
            .ForMember(dest => dest.Education, opt => opt.MapFrom(src => src.Education))
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture));



            CreateMap<AddPostRequestDto, Post>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));


            CreateMap<Post, AddPostResponseDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<UpdatePostRequestDto, Post>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PostId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));


            CreateMap<Post, UpdatePostResponseDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));


            CreateMap<AddFriendRequestDto, FriendsRelationship>()
                .ForMember(dest => dest.FirstUserId, opt => opt.MapFrom(src => src.CurrentUserId))
                .ForMember(dest => dest.SecondUserId, opt => opt.MapFrom(src => src.FriendId));

            CreateMap<AddCommentRequestDto, Comment>()
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));


            CreateMap<Comment, AddCommentResponseDto>()
               .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
               .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.User, opt => opt.MapFrom(src => new User()
               {
                   FirstName=src.User.FirstName,
                   LastName=src.User.LastName,
                   ProfilePicture=src.User.ProfilePicture
               }))
               .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated));

            CreateMap<Comment, UpdateCommentResponseDto>()
               .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
               .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated));




            CreateMap<AddLikeRequestDto, Like>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId));

            CreateMap<Post, GetUserPostsResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));


            CreateMap<Post, GetNewsFeedPostsResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
            //CreateMap<User, GetFriendRequestsResponseDto>()
            //  .ForMember(dest => dest.FriendId, opt => opt.MapFrom(src => src.Id))
            //  .ForMember(dest => dest.FriendFirstName, opt => opt.MapFrom(src => src.FirstName))
            //  .ForMember(dest => dest.FriendLastName, opt => opt.MapFrom(src => src.LastName));
        }
    }
}
