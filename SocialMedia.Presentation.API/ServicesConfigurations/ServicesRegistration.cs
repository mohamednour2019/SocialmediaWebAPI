using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.Like.ResponseDTOs;
using SocialMedia.Core.Services.AzureBlobServices;
using SocialMedia.Core.Services.EmailServices;
using SocialMedia.Core.Services.FriendshipServices;
using SocialMedia.Core.Services.HubServices;
using SocialMedia.Core.Services.MessegesServices;
using SocialMedia.Core.Services.NotificationsServices;
using SocialMedia.Core.Services.OTPServices;
using SocialMedia.Core.Services.PostServices;
using SocialMedia.Core.Services.PostServices.CommentServices;
using SocialMedia.Core.Services.PostServices.CommentServices.ReplyServices;
using SocialMedia.Core.Services.PostServices.LikeServices;
using SocialMedia.Core.Services.SSEServices;
using SocialMedia.Core.Services.TokenHanlderService;
using SocialMedia.Core.Services.TokenServices;
using SocialMedia.Core.Services.UserServices;
using SocialMedia.Core.ServicesInterfaces;
using SocialMedia.Core.ServicesInterfaces.AzureBlobInterfaces;
using SocialMedia.Core.ServicesInterfaces.EmailInterfaces;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using SocialMedia.Core.ServicesInterfaces.HubInterfaces;
using SocialMedia.Core.ServicesInterfaces.MessegesInterfaces;
using SocialMedia.Core.ServicesInterfaces.NotificatinosInterfaces;
using SocialMedia.Core.ServicesInterfaces.OTP;
using SocialMedia.Core.ServicesInterfaces.OTPInterfaces;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces.ReplyInterfaces;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.LikeInterfaces;
using SocialMedia.Core.ServicesInterfaces.SSEInterfaces;
using SocialMedia.Core.ServicesInterfaces.TokenHandler;
using SocialMedia.Core.ServicesInterfaces.TokenInterfaces;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;
using SocialMedia.Infrastructure.DatabaseContext;
using SocialMedia.Infrastructure.Mapper;
using SocialMedia.Infrastructure.Repositories;
using SocialMedia.Infrastructure.Repositories.ChatRepository;
using SocialMedia.Infrastructure.Repositories.CommentRepository;
using SocialMedia.Infrastructure.Repositories.Friendship;
using SocialMedia.Infrastructure.Repositories.LikeRepository;
using SocialMedia.Infrastructure.Repositories.MessegesRepository;
using SocialMedia.Infrastructure.Repositories.MessengerHubRepository;
using SocialMedia.Infrastructure.Repositories.NotificationRepository;
using SocialMedia.Infrastructure.Repositories.PostRepository;
using SocialMedia.Infrastructure.Repositories.ReplyRepository;
using SocialMedia.Infrastructure.Repositories.UserRepository;
using SocialMedia.Presentation.API.Filters;
using System.Text;

namespace SocialMedia.Presentation.API.ServicesConfigurations
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services,IConfiguration configuration)
        {
            // Add controllers with custom model state validation
            services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole("RiverUser").Build();
                options.Filters.Add(new AuthorizeFilter(policy));

            }).ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                    RequestDtoValidationActionFilter.OnActionExecuting(context);

            });

            // Add HttpClient
            services.AddHttpClient();

            // EF Core and Identity registration
            services.AddDbContext<AppDbContext>();
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddUserStore<UserStore<User, Role, AppDbContext, Guid>>()
            .AddRoleStore<RoleStore<Role, AppDbContext, Guid>>()
            .AddDefaultTokenProviders();

            // AutoMapper registration
            services.AddAutoMapper(typeof(Mapper));

            // Swagger configuration registration
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Social Media API v1",
                    Version = "v1"
                });
            });

            // API versioning registration
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            // Custom services registration
            RegisterCustomServices(services);

            // SignalR registration
            services.AddSignalR();
            services.AddSingleton<INotificationHubService, NotificationHubService>();

            // CORS registration
            services.AddCors();


            //Add Authentication and Authorization
            var Audeience = configuration["JWT:Audeience"];
            var Issuer = configuration["JWT:Issuer"];
            var key = configuration["JWT:SecurityKey"];
            AddCustomAuthentication(services,Audeience, Issuer, key);
            AddCustomAuthorization(services);

            return services;
        }

        private static void RegisterCustomServices(IServiceCollection services)
        {
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ISignInService, SignInService>();
            services.AddScoped<IAddPostService, AddPostService>();
            services.AddScoped<IUpdatePostService, UpdatePostService>();
            services.AddScoped<IDeletePostService, DeletePostService>();
            services.AddScoped<IAddFriendService, AddFriendService>();
            services.AddScoped<IGenericRepository<Post>, GenericRepository<Post>>();
            services.AddScoped<IGenericRepository<FriendsRelationship>, GenericRepository<FriendsRelationship>>();
            services.AddScoped<IFriendshipRepository, FriendshipRepository>();
            services.AddScoped<IAcceptFriendRequestService, AcceptFriendRequestService>();
            services.AddScoped<IUnfriendService, UnfriendService>();
            services.AddScoped<IRejectFriendRequestService, RejectFriendRequestService>();
            services.AddScoped<IAddCommentService, AddCommentService>();
            services.AddScoped<IGenericRepository<Comment>, GenericRepository<Comment>>();
            services.AddScoped<IDeleteCommentService, DeleteCommentService>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IUpdateCommentService, UpdateCommentService>();
            services.AddScoped<IAddLikeService, AddLikeService>();
            services.AddScoped<IUnlikeService, UnlikeService>();
            services.AddScoped<IGenericRepository<Like>, GenericRepository<Like>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenerateOtpService, GenerateOtpService>();
            services.AddScoped<IVerifyOtpService, VerifyOtpService>();
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            services.AddScoped<ISendEmailService, SendEmailService>();
            services.AddScoped<IUpdateOtpService, UpdateOtpService>();
            services.AddScoped<IGetUserPostsService, GetUserPostsService>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IGetNewsFeedPostsService, GetNewsFeedPostsService>();
            services.AddScoped<IAddSelfRelationFriendshipService, AddSelfRelationFriendshipService>();
            services.AddScoped<IGetFirendsService, GetFirendsService>();
            services.AddScoped<IGetPostService, GetPostService>();
            services.AddScoped<ISendLiveNotificationService, SendLiveNotificationService>();
            services.AddScoped<IGenericRepository<Notification>, GenericRepository<Notification>>();
            services.AddScoped<IGetNotificationService, GetNotificationService>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IGetNotificationsService, GetNotificationsService>();
            services.AddScoped<IGenericRepository<Message>, GenericRepository<Message>>();
            services.AddScoped<IMessegesRepository, MessegesRepository>();
            services.AddScoped<IGetChatMessegesService, GetChatMessegesService>();
            services.AddScoped<IGenericRepository<MessengerHub>, GenericRepository<MessengerHub>>();
            services.AddScoped<ILogoutService, LogoutService>();
            services.AddScoped<IMessengerHubRepository, MessengerHubRepository>();
            services.AddScoped<IAddMessageService, AddMessegeService>();
            services.AddScoped<IMessengerHubService, MessengerHubService>();
            services.AddScoped<IGetUserService, GetUserService>();
            services.AddScoped<IGetFriendRequests, GetFriendRequests>();
            services.AddScoped<IGetFriendSuggestionsService, GetFriendSuggestionsService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISearchUserService, SearchUserService>();
            services.AddScoped<IUploadImageServie, UploadImageServie>();
            services.AddScoped<IGetCommentsService, GetCommentsService>();  
            services.AddScoped<ILikesRepository,LikesRepository>();
            services.AddScoped<IGetLikesService, GetLikesService>();    
            services.AddScoped<IDeleteUserConnectionService, DeleteUserConnectionService>();
            services.AddScoped<IAddProfilePictureService, AddProfilePictureService>();
            services.AddScoped<IAddCoverPictureService, AddCoverPictureService>();
            services.AddScoped<ITokenHandlerService, TokenHandlerService>();
            services.AddScoped<IGetClaimsFromToken,GetClaimsFromToken>();
            services.AddScoped<ISharePostService, SharePostService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();    
            services.AddScoped<IChatRepository,ChatRepository>();
            services.AddScoped<IGetUserChatsService, GetUserChatsService>();
            services.AddScoped<IReplyRepository, ReplyRepository>();
            services.AddScoped<IAddReplyService,AddReplyService>();
            services.AddScoped<IGetOnlineFriendsService, GetOnlineFriendsService>();
            services.AddScoped<IGenericRepository<UserRefreshToken>, GenericRepository<UserRefreshToken>>();
           
        }

        public static void AddCustomAuthentication(IServiceCollection services, string Audience,string Issuer,string key)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidAudience = Audience,
                    ValidIssuer = Issuer,
                    ValidateIssuerSigningKey = true,
                    ClockSkew=TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });
        }

        public static void AddCustomAuthorization(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("authenticated", policy =>
                {
                    policy.RequireAuthenticatedUser();
                });
                options.AddPolicy("RiverUser", policy =>
                {
                    policy.RequireRole("RiverUser");
                });
            });
        }
    }

}
