using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Services;
using Forum.Entities;
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
        public IActionResult OnPost(Post p)
        {
            _forumService.Create(p)
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

