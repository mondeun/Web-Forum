    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Forum.data.DTO;
using Web_Forum.Models;

namespace Web_Forum.Helpers
{
    public static class Helper
    {
        public static ThreadDTO Transform(this ThreadViewModel thread)
        {
            var dto = new ThreadDTO
            {
                Title = thread.Title,
                Name = thread.Name,
                Text = thread.Text
            };
            return dto;
        }

        public static PostDTO Transform(this PostViewModel post)
        {
            var dto = new PostDTO
            {
                ThreadId = post.ThreadId,
                Name = post.Name,
                Text = post.Text

            };
            return dto;
        }
        public static PostViewModel Transform(this PostDTO post)
        {
            var dto = new PostViewModel
            {
                ThreadId = post.ThreadId,
                Name = post.Name,
                Text = post.Text
            };
            return dto;
        }
    }
}
