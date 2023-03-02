using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Forum.Entities;
using Forum.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        private readonly IForumService _forumService;
        public HomeController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpPost]
        public IActionResult Index(Post p, IFormFile file)
        {
            byte[] bytes;
            if (file != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.OpenReadStream().CopyTo(ms);
                    bytes = ms.ToArray();
                }
                p.image = bytes;
            }
            
            _forumService.Create(p);
            var posts = _forumService.GetAll();
            return View(posts);
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            var posts = _forumService.GetAll();
            return View(posts);
        }
    }

}