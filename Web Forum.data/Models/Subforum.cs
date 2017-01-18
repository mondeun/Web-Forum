using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Forum.data.Models;

namespace Web_Forum.data
{
    public class Subforum
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<Topic> Topics { get; set; }
    }
}
