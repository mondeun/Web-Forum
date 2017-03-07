using System;

namespace Web_Forum.data.DTO
{
    public class PostDTO
    {
        public Guid Id { get; set; }
        public Guid ThreadId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Posted { get; set; }
        public int Likes { get; set; }
    }
}
