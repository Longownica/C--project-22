using Forum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum
{
    public class PostSeeder
    {
        private readonly ForumDbContext _dbContext;

        public PostSeeder(ForumDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Posts.Any())
                {
                    var posts = GetPosts();
                    _dbContext.Posts.AddRange(posts);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Post> GetPosts()
        {
            var posts = new List<Post>()
            {
                new Post()
                {
                    body = "Witamy na naszym super forum elo",
                    date = DateTime.Now,
                    nickname = "Admin",
                    topic = "Post powitalny",
                    image = null,
                    answerTo = -1
                }
            };
            return posts;
        }
    }
}
