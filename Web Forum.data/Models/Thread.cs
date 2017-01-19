using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Web_Forum.data.Models
{
    public class Thread
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<Post> Posts { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastPosted { get; set; }

        public Thread()
        {
            Posts = new HashSet<Post>();
        }
    }
}
