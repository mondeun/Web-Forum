using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Forum.data.DTO
{
    public class PostDTO
    {
        public Guid ThreadId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Posted { get; set; }
    }
}
