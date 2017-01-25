using System;

namespace Web_Forum.Models
{
    public class PostViewModel
    {
        public Guid ThreadId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Posted { get; set; }
    }
}