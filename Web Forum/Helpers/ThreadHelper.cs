using System.Collections.Generic;
using System.Linq;
using Web_Forum.data.DTO;
using Web_Forum.Models;

namespace Web_Forum.Helpers
{
    public static class ThreadHelper
    {
        public static ThreadDTO Transform(ThreadViewModel thread) => new ThreadDTO
        {
            Title = thread.Title,
            Name = thread.Name,
            Text = thread.Text
        };

        public static IndexThreadDTO Transform(IndexThreadViewModel thread) => new IndexThreadDTO
        {
            Id = thread.Id,
            Title = thread.Title,
            DateCreated = thread.LastPosted,
            LastPosted = thread.LastPosted,
            NumberOfPosts = thread.NumberOfPosts,
            Likes = thread.Likes
        };

        public static IndexThreadViewModel Transform(IndexThreadDTO thread) => new IndexThreadViewModel
        {
            Id = thread.Id,
            Title = thread.Title,
            DateCreated = thread.LastPosted,
            LastPosted = thread.LastPosted,
            NumberOfPosts = thread.NumberOfPosts,
            Likes = thread.Likes
        };

        public static List<IndexThreadViewModel> Transform(IEnumerable<IndexThreadDTO> dtos)
        {
            return dtos?.Select(x => new IndexThreadViewModel
            {
                Id = x.Id,
                Title = x.Title,
                DateCreated = x.DateCreated,
                LastPosted = x.LastPosted,
                NumberOfPosts = x.NumberOfPosts,
                Likes = x.Likes
            }).ToList();
        }
    }
}
