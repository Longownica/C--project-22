using Forum.Controllers;
using Forum.Entities;
using Forum.Models;
using Forum.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Views.Home
{
    [BindProperties]
    public class Index : PageModel
    {

        private readonly ForumDbContext _db;
        public string topic { get; set; }
        public string nickname { get; set; }
        public string body { get; set; }
        public int answerTo { get; set; }
        public byte[] image { get; set; }

        public Index(ForumDbContext db)
        {
            _db = db;
        }

    }
}
