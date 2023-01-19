using Forum.Entities;
using Forum.Models;
using Forum.Services;
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
        private readonly IForumService _forumService;
        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _forumService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreatePost([FromBody] Post cp)
        {
            var id = _forumService.Create(cp);
            return Created($"/api/forum/{id}", null);
        }
       

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAll()
        {
            var posts = _forumService.GetAll();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public ActionResult<Post> Get([FromRoute] int id)
        {
            var post = _forumService.GetById(id);
            if(post is null)
            {
                return NotFound();
            }

            return Ok(post);
        }
    }
}
