using Asp.Versioning;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.Services.FriendshipServices;
using SocialMedia.Core.Services.PostServices;
using SocialMedia.Core.Services.PostServices.CommentServices;
using SocialMedia.Core.Services.UserServices;
using SocialMedia.Core.ServicesInterfaces.FriendshipInterfaces;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces;
using SocialMedia.Core.ServicesInterfaces.PostInterfaces.CommentInterfaces;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;
using SocialMedia.Infrastructure.DatabaseContext;
using SocialMedia.Infrastructure.Mapper;
using SocialMedia.Infrastructure.Repositories;
using SocialMedia.Infrastructure.Repositories.CommentRepository;
using SocialMedia.Infrastructure.Repositories.Friendship;

namespace SocialMedia.Presentation.API.ServicesConfigurations
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection Services)
        {
            //add controllers
             Services.AddControllers();

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
            Services.AddScoped<IRejectFriendRequestService,RejectFriendRequestService>();   
            Services.AddScoped<IGetFriendRequestsService,GetFriendRequestsService>();
            Services.AddScoped<IAddCommentService,AddCommentService>();
            Services.AddScoped<IGenericRepository<Comment>,GenericRepository<Comment>>();
            Services.AddScoped<IDeleteCommentService,DeleteCommentService>();
            Services.AddScoped<ICommentRepository,CommentRepository>();
            Services.AddScoped<IUpdateCommentService,UpdateCommentService>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();


            return Services;
        }
    }
}
