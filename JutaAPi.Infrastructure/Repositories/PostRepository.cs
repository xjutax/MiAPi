using JutaApi.Core.Entities;
using JutaApi.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JutaAPi.Infrastructure.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly IConfiguration _config;
        private readonly string nombre;
        private readonly ILogger _elloguer;

        public PostRepository( IConfiguration config, ILogger elloguer) : base(typeof(Post).Name, config)
        {
            _config = config;
            _elloguer = elloguer;
        }
        //public async Task<IEnumerable<Post>> GetPosts()
        //{
        //    var posts = Enumerable.Range(1, 10).Select(x => new Post
        //    {
        //        PostId = x,
        //        Description = $"Descripcion {x}",
        //        Date = System.DateTime.Now,
        //        Image = "https://localhost/{x}",
        //        UserId = x
        //    });
        //    await Task.Delay(10);
        //    return posts;
        //}
        public async Task<Post> GetByIdAsync(int id)
        {
            _elloguer.LogWarning("pipi");
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                _elloguer.LogError(ex, ex.Message);
            }
            var result = await GetAllAsync();
            var subresult = result.Where(x => x.PostId == id).FirstOrDefault();
            return subresult;
        }
    }
}
