using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Forum.Models
{
    public class ThreadViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }
        public DateTime DateCreated { get; set; }
    }
}