using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<List<User>> SearchUserAsync(params string[] keyWords)
        {
            List<User> users;
            if (keyWords.Count() == 1)
            {
               users = await _dbContext.Users.Where(x => x.FirstName.StartsWith(keyWords[0]) 
                             || x.LastName.StartsWith(keyWords[0])).ToListAsync();
            }
            else
            {
                users= await _dbContext.Users.Where(x => (x.FirstName.StartsWith(keyWords[0]) 
                             && x.LastName.StartsWith(keyWords[1]))||
                             (x.FirstName.StartsWith(keyWords[0])
                             || x.LastName.StartsWith(keyWords[1]))
                             ).ToListAsync();

            }
            users.DistinctBy(x => x.Id);
            return users;
        }
    }
}
