using System;
using System.ComponentModel.DataAnnotations;

namespace Web_Forum.Models
{
    public class IndexThreadViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastPosted { get; set; }
        public int NumberOfPosts { get; set; }
        public int Likes { get; set; }
    }
}