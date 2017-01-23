using System;
using System.Collections.Generic;

namespace Web_Forum.data.Models
{
    public class Thread
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastPosted { get; set; }
        public int Likes { get; set; }

        public Thread()
        {
            Posts = new HashSet<Post>();
        }
    }
}
