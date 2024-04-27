using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T>where T : class
    {
        private AppDbContext _context;
        private DbSet<T> _set;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();  
        }

        public async Task Delete(Guid id)
        {
            T result = await FindAsync(id);
            _set.Remove(result);
            await _context.SaveChangesAsync();
        }


        public async Task Delete(params object[] keyValues)
        {
            T result = await FindAsync(keyValues);
            _set.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<T> FindAsync(Guid id)
        {
            T ? result = await _set.FindAsync(id);
            return result;
        }

        public async Task<T> FindAsync(params object[] keyValues)
        {
            T? result = await _set.FindAsync(keyValues);
            return result;
        }


    }
}
