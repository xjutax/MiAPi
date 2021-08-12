using JutaApi.Core.Entities;
using JutaAPi.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JutaApi.Core.Interfaces
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<Post> GetByIdAsync(int id);
    }
}
