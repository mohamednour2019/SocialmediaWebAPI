using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.RepositoriesInterfaces
{
    public interface IGenericRepository<T>
    {
        Task AddAsync(T entity);
        Task<T>FindAsync(Guid id);

        Task<T> FindAsync(params object[] keyValues);
        Task Delete(Guid id);

        Task Delete(params object[] keyValues);
    }
}
