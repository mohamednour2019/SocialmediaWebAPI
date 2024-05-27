using Asp.Versioning;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.Services;
using SocialMedia.Core.Services.FriendshipServices;
using SocialMedia.Core.Services.HubServices;
using SocialMedia.Core.Services.MessegesServices;
using SocialMedia.Core.Services.NotificationsServices;
using SocialMedia.Core.Services.OTPServices;
using SocialMedia.Core.Services.PostServices;
using SocialMedia.Core.Services.PostServices.CommentServices;
using SocialMedia.Core.Services.PostServices.LikeServices;
using SocialMedia.Core.Services.SSEServices;
using SocialMedia.Core.Services.UserServices;
using SocialMedia.Core.ServicesInterfaces;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using SocialMedia.Core.ServicesInterfaces.HubInterfaces;
using SocialMedia.Core.ServicesInterfaces.MessegesInterfaces;
using SocialMedia.Core.ServicesInterfaces.NotificatinosInterfaces;
using SocialMedia.Core.ServicesInterfaces.OTP;
using SocialMedia.Core.ServicesInterfaces.OTPInterfaces;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.LikeInterfaces;
using SocialMedia.Core.ServicesInterfaces.SSEInterfaces;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;
using SocialMedia.Infrastructure.DatabaseContext;
using SocialMedia.Infrastructure.Mapper;
using SocialMedia.Infrastructure.Repositories;
using SocialMedia.Infrastructure.Repositories.CommentRepository;
using SocialMedia.Infrastructure.Repositories.Friendship;
using SocialMedia.Infrastructure.Repositories.MessegesRepository;
using SocialMedia.Infrastructure.Repositories.MessengerHubRepository;
using SocialMedia.Infrastructure.Repositories.NotificationRepository;
using SocialMedia.Infrastructure.Repositories.PostRepository;
using SocialMedia.Infrastructure.Repositories.UserRepository;
using SocialMedia.Presentation.API.Filters;

namespace SocialMedia.Presentation.API.ServicesConfigurations
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection Services)
        {

            //add controllers
            Services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context => RequestDtoValidationActionFilter.OnActionExecuting(context);
            });
             Services.AddHttpClient();


            //ef core  and identity registration
            Services.AddDbContext<AppDbContext>();
            Services.AddIdentity<User, Role>(options =>
           {
               options.Password.RequireUppercase = true;
               options.Password.RequireLowercase = true;
               options.Password.RequiredLength = 10;

           }).AddEntityFrameworkStores<AppDbContext>()
             .AddUserStore<UserStore<User, Role, AppDbContext, Guid>>()
             .AddRoleStore<RoleStore<Role, AppDbContext, Guid>>()
             .AddDefaultTokenProviders();

             //auto mapper registration
             Services.AddAutoMapper(typeof(Mapper));


             //swagger configuration registration
             Services.AddEndpointsApiExplorer();
             Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Social Media API v1",
                    Version = "v1"
                });
            });
             Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });


            //custom services registration
            Services.AddScoped<IRegisterService, RegisterService>();
            Services.AddScoped<ISignInService, SignInService>();
            Services.AddScoped<IAddPostService,AddPostService>();
            Services.AddScoped<IUpdatePostService,UpdatePostService>(); 
            Services.AddScoped<IDeletePostService, DeletePostService>();
            Services.AddScoped<IAddFriendService,AddFriendService>();
            Services.AddScoped<IGenericRepository<Post>,GenericRepository<Post>>();
            Services.AddScoped<IGenericRepository<FriendsRelationship>,GenericRepository<FriendsRelationship>>();
            Services.AddScoped<IFriendshipRepository,FriendshipRepository>();
            Services.AddScoped<IAcceptFriendRequestService,AcceptFriendRequestService>();
            Services.AddScoped<IUnfriendService,UnfriendService>();   
            Services.AddScoped<IRejectFriendRequestService,RejectFriendRequestService>();
            Services.AddScoped<IAddCommentService,AddCommentService>();
            Services.AddScoped<IGenericRepository<Comment>,GenericRepository<Comment>>();
            Services.AddScoped<IDeleteCommentService,DeleteCommentService>();
            Services.AddScoped<ICommentRepository,CommentRepository>();
            Services.AddScoped<IUpdateCommentService,UpdateCommentService>();
            Services.AddScoped<IAddLikeService,AddLikeService>();
            Services.AddScoped<IUnlikeService,UnlikeService>();
            Services.AddScoped<IGenericRepository<Like>,GenericRepository<Like>>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IGenerateOtpService, GenerateOtpService>();
            Services.AddScoped<IVerifyOtpService,VerifyOtpService>();   
            Services.AddScoped<IGenericRepository<User>,GenericRepository<User>>();
            Services.AddScoped<ISendEmailService,SendEmailService>();
            Services.AddScoped<IUpdateOtpService,UpdateOtpService>();
            Services.AddScoped<IGetUserPostsService,GetUserPostsService>();
            Services.AddScoped<IPostRepository, PostRepository>();
            Services.AddScoped<IGetNewsFeedPostsService,GetNewsFeedPostsService>();
            Services.AddScoped<IAddSelfRelationFriendshipService,AddSelfRelationFriendshipService>();
            Services.AddScoped<IGetFirendsService,GetFirendsService>();
            Services.AddScoped<IGetPostService,GetPostService>();
            Services.AddSignalR();
            Services.AddSingleton<INotificationHubService, NotificationHubService>();
            Services.AddScoped<ISendLiveNotificationService,SendLiveNotificationService>();
            Services.AddScoped<IGenericRepository<Notification>,GenericRepository<Notification>>();
            Services.AddScoped<IGetNotificationService,GetNotificationService>();
            Services.AddScoped<INotificationRepository, NotificationRepository>();
            Services.AddScoped<IGetNotificationsService,GetNotificationsService>();


            Services.AddScoped<IGenericRepository<Message>,GenericRepository<Message>>();
            Services.AddScoped<IMessegesRepository,MessegesRepository>();   
            Services.AddScoped<IGetChatMessegesService,GetChatMessegesService>();
            Services.AddScoped<IGenericRepository<MessengerHub>,GenericRepository<MessengerHub>>();
            Services.AddScoped<ILogoutService,LogoutService>();
            Services.AddScoped<IMessengerHubRepository, MessengerHubRepository>();
            Services.AddScoped<IAddMessageService, AddMessegeService>();
            Services.AddScoped<IMessengerHubService,MessengerHubService>();
            Services.AddScoped<IGetUserService, GetUserService>();
            Services.AddScoped<IGetFriendRequests, GetFriendRequests>();
            Services.AddScoped<IGetFriendSuggestionsService,GetFriendSuggestionsService>();
            Services.AddScoped<IUserRepository,UserRepository>();
            Services.AddScoped<ISearchUserService,SearchUserService>();
            Services.AddCors();
            return Services;
        }

    }
}
