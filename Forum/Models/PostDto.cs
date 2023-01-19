using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class PostDto
    {
        public int Id { get; set; }
        public string body { get; set; }
        public DateTime date { get; set; }
        public string nickname { get; set; }
        public string topic { get; set; }
        public byte[] image { get; set; }
        public int answerTo { get; set; }
    }
}
