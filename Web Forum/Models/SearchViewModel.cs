using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Forum.Models
{
    public class SearchViewModel
    {
        public List<IndexThreadViewModel> Threads { get; set; }
        public List<PostViewModel> Posts { get; set; }
    }
}