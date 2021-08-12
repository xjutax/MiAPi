using JutaApi.Core.Entities;
using JutaApi.Core.Interfaces;
using JutaAPi.Infrastructure.Interfaces;
using JutaAPi.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JutaApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repo;
        private readonly ILogger<PostController> _elloguer;
        public PostController(IPostRepository repo, ILogger<PostController> elloguer)
        {
            _repo = repo;
            _elloguer = elloguer;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {                      
            return Ok(await _repo.GetByIdAsync(1));
        }
    }
}
