using AutoMapper;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class GenericService<T> where T : class
    {
        protected IMapper _mapper;
        protected IGenericRepository<T> _repository;
        public GenericService(IMapper mapper, IGenericRepository<T> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
