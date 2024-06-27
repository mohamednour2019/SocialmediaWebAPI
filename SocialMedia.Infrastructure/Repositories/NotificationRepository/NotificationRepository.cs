using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.NotificationRepository
{
    public class NotificationRepository : INotificationRepository
    {
        private AppDbContext _appDbContext;
        private DbSet<Notification> _set; 
        public NotificationRepository(AppDbContext context)
        {
            _appDbContext=context;
            _set=_appDbContext.Set<Notification>();
        }

        public async Task<Notification>GetNotification(Guid NotificationId)
        {
            Notification notification=await _set.FindAsync(NotificationId);
            User emmiter=await _appDbContext.Users.FindAsync(notification.EmmiterId);
            notification.NotificationImage = emmiter.ProfilePicture;
            return notification;
        }
        public async Task<List<Notification>> GetNotifications(Guid userId)
        {
                List<Notification> notifications=
                await _set.Where(x=> x.UserId == userId)
                .Join(_appDbContext.Users,x=>x.EmmiterId,x=>x.Id,
                (notification,user)=> new Notification()
                {
                    Id = notification.Id,
                    EmmiterId = notification.EmmiterId,
                    DateTime = notification.DateTime,
                    NotificationType = notification.NotificationType,
                    PostId = notification.PostId,
                    User = notification.User,
                    UserId = notification.UserId,
                    EmmiterName = notification.EmmiterName,
                    NotificationImage = user.ProfilePicture
                }).OrderByDescending(x=>x.DateTime).ToListAsync();
                return notifications;   
        }

        public async Task DeletePostNotifications(Guid PostId)
            => await _appDbContext.Notifications.Where(x => x.PostId == PostId).ExecuteDeleteAsync();
    }
}
