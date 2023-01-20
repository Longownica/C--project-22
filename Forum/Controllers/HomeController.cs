using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Services;
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
        // GET: /<controller>/
        public IActionResult Index()
        {
            var posts = _forumService.GetAll();
            return View(posts);
        }
    }
}

