﻿using AutoMapper;
using Microsoft.Data.SqlClient;
using SendGrid.Helpers.Mail;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.DTO_S.Comment.ResponseDTOs;
using SocialMedia.Core.DTO_S.Friendship.ResponseDTOs;
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
                .ForMember(dest => dest.CoverPictureUrl, opt => opt.MapFrom(src => src.CoverPictureUrl))
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.ProfilePicture));


            CreateMap<User, GetFriendGenericResposneDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            .ForMember(dest => dest.Relationship, opt => opt.MapFrom(src => src.Relationship))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Work, opt => opt.MapFrom(src => src.Work))
            .ForMember(dest => dest.Education, opt => opt.MapFrom(src => src.Education))
            .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.ProfilePicture));



            CreateMap<AddPostRequestDto, Post>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));


            CreateMap<Post, AddPostResponseDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime))
                .ForMember(dest=>dest.PostImageUrl,opt=>opt.MapFrom(src=>src.ImageUrl))
                .ForMember(dest => dest.PostImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.Id));

            CreateMap<UpdatePostRequestDto, Post>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PostId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));


            CreateMap<Post, UpdatePostResponseDto>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));


            CreateMap<AddFriendRequestDto, FriendsRelationship>()
                .ForMember(dest => dest.FirstUserId, opt => opt.MapFrom(src => src.CurrentUserId))
                .ForMember(dest => dest.SecondUserId, opt => opt.MapFrom(src => src.FriendId));

            CreateMap<AddCommentRequestDto, Comment>()
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));


            CreateMap<Comment, CommentResponseDto>()
               .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
               .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
               .ForMember(dest => dest.CommentId, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
               .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.User.ProfilePicture));

            CreateMap<Comment, UpdateCommentResponseDto>()
               .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
               .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated));




            CreateMap<AddLikeRequestDto, Like>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId));

            //CreateMap<Post, GetUserPostsResponseDto>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            //    .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
            //    .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime))
            //    .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes))
            //    .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            //    .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            //    .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));


            //CreateMap<Post, GetNewsFeedPostsResponseDto>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            //    .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
            //    .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime))
            //    .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes))
            //    .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            //    .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            //    .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));

            CreateMap<Post, GetUserPostsResponseDto>()
               .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime))
               .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
               .ForMember(dest => dest.PostImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
               .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
               .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName))
               .ForMember(dest => dest.UserProfilePictureUrl, opt => opt.MapFrom(src => src.User.ProfilePicture))
               .ForMember(dest => dest.LikesCount, opt => opt.MapFrom(src => src.Likes.Count()))
               .ForMember(dest => dest.CommentsCount, opt => opt.MapFrom(src => src.Comments.Count()))
               .ForMember(dest => dest.isLiked, opt => opt.MapFrom(src => src.Likes.Any(x => x.UserId == src.UserId)));



            CreateMap<Notification, GetNotificationResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
                .ForMember(dest => dest.NotificationType, opt => opt.MapFrom(src => src.NotificationType))
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.NotificationImage))
                .ForMember(dest => dest.EmmiterName, opt => opt.MapFrom(src => src.EmmiterName))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime));

            CreateMap<Message, GetChatMessegesResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.ReciverId))
                .ForMember(dest => dest.SenderId, opt => opt.MapFrom(src => src.SenderId));

            CreateMap<User, GetUserResponseDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Relationship, opt => opt.MapFrom(src => src.Relationship))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Work, opt => opt.MapFrom(src => src.Work))
                .ForMember(dest => dest.Education, opt => opt.MapFrom(src => src.Education))
                .ForMember(dest => dest.CoverPictureUrl, opt => opt.MapFrom(src => src.CoverPictureUrl))
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.ProfilePicture));

           CreateMap<User,GetFriendsSuggestionsResponseDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.ProfilePicture))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<User, GetFriendRequestsResponseDto>()
                 .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                 .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                 .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.ProfilePicture))
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<User, GetOnlineFriendsResponseDto>()
                 .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                 .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                 .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.ProfilePicture))
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<User, SearchUserResponseDto>()
                .ForMember(dest => dest.Id, otp => otp.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, otp => otp.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.ProfilePictureUrl, otp => otp.MapFrom(src => src.ProfilePicture))
                .ForMember(dest => dest.LastName, otp => otp.MapFrom(src => src.LastName));

        }
    }
}
