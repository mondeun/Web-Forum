using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Forum.data.DTO
{
    public class IndexThreadDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastPosted { get; set; }
        public int NumberOfPosts { get; set; }
    }
}
