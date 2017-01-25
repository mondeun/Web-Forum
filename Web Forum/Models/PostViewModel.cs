using System;
using System.ComponentModel.DataAnnotations;

namespace Web_Forum.Models
{
    public class PostViewModel
    {
        public Guid ThreadId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public DateTime Posted { get; set; }

        public int Likes { get; set; }
    }
}