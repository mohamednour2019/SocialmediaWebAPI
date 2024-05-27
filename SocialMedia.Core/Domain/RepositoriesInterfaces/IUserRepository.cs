using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Domain.RepositoriesInterfaces
{
    public interface IUserRepository
    {

        Task<List<User>> SearchUserAsync(params string []keyWords);
    }
}
