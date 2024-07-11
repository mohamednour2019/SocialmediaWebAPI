using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialMedia.Core.Domain.Entities;

namespace SocialMedia.Infrastructure.DatabaseContext
{
    public class AppDbContext:IdentityDbContext<User,Role,Guid>
    {
        private IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration)
        {
            _configuration  = configuration;
        }
        public DbSet<User> Users {  get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<FriendsRelationship> Friends { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<MessengerHub> MessengerHub { get; set; }
        
        public DbSet<UserRefreshToken> UserRefreshToken { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<Like>Likes { get; set; }

        public DbSet<Chat> Chats { get; set; }
        
        public DbSet<Reply> Replies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
