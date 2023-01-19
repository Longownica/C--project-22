using Forum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services
{
    public interface IForumService
    {
        int Create(Post cp);
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        bool Delete(int id);
    }

    public class ForumService : IForumService
    {
        private readonly ForumDbContext _dbContext;
        public ForumService(ForumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Delete(int id)
        {
            var post = _dbContext
               .Posts
               .First(r => r.Id == id);

            if (post is null) return false;
            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
            return true;
        }

        public Post GetById(int id)
        {
            var post = _dbContext
               .Posts
               .First(r => r.Id == id);

            if (post is null)
            {
                return null;
            }
            return post;
        }

        public IEnumerable<Post> GetAll()
        {
            var posts = _dbContext
                .Posts
                .ToList();
            return posts;
        }

        public int Create(Post cp)
        {
            var post = cp;
            DateTime date = DateTime.Now;
            cp.date = date;
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
            return post.Id;
        }
    }
}
