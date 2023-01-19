using Forum.Entities;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    [Route("api/forum")]
    public class ForumController : ControllerBase
    {
        private readonly ForumDbContext _dbContext;
        public ForumController(ForumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult CreatePost([FromBody] Post cp)
        {

            var post = cp;
            DateTime date = DateTime.Now;
            cp.date = date;
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();

            return Created($"/api/forum/{post.Id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAll()
        {
            var posts = _dbContext
                .Posts
                .ToList();

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public ActionResult<Post> Get([FromRoute] int id)
        {
            var post = _dbContext
                .Posts
                .FirstOrDefault(r => r.Id == id);

            if(post is null)
            {
                return NotFound();
            }

            return Ok(post);
        }

    }
}
