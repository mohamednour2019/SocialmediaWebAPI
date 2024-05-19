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
        public async Task<List<Notification>> GetNotifications(Guid userId)
            =>await _set.Where(x=>x.UserId == userId).ToListAsync();
    }
}
