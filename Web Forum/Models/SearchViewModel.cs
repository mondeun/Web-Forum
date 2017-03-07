using System.Collections.Generic;

namespace Web_Forum.Models
{
    public class SearchViewModel
    {
        public List<IndexThreadViewModel> Threads { get; set; }
        public List<PostViewModel> Posts { get; set; }

        public SearchViewModel()
        {
            Threads = new List<IndexThreadViewModel>();
            Posts = new List<PostViewModel>();
        }
    }
}