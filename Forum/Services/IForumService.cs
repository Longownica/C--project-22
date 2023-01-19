using Forum.Entities;
using System.Collections.Generic;

namespace Forum.Services
{
    public interface IForumService
    {
        void Create(Post cp);
        IEnumerable<Post> GetAll();
        Post GetById(int id);
    }
}