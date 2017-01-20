using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Forum.data.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Posted { get; set; }
        public Guid ThreadId { get; set; }

        public virtual Thread Thread { get; set; }
    }
}
