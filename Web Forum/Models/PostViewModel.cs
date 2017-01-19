using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Forum.Models
{
    public class PostViewModel
    {
        public Guid ThreadId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Posted { get; set; }

        // First Post

        public Guid PostId { get; set; }
        public string Title { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }
        public DateTime DateCreated { get; set; }
    }
}