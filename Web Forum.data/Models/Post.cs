using System;

namespace Web_Forum.data.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Posted { get; set; }
        public Guid ThreadId { get; set; }

        public Thread Thread { get; set; }
    }
}
