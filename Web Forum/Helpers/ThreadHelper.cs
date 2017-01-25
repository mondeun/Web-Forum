using System.Collections.Generic;
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

        public static List<PostViewModel> Transform(this List<PostViewModel> models, List<PostDTO> dtos)
        {
            dtos.ForEach(x => models.Add(new PostViewModel
            {
                ThreadId = x.ThreadId,
                Name = x.Name,
                Text = x.Text,
                Posted = x.Posted
            }));

            return models;
        }

        public static List<IndexThreadViewModel> Transform(this List<IndexThreadViewModel> models, List<IndexThreadDTO> dtos)
        {
            dtos.ForEach(x => models.Add(new IndexThreadViewModel
            {
                Id = x.Id,
                Title = x.Title,
                DateCreated = x.DateCreated,
                LastPosted = x.LastPosted,
                NumberOfPosts = x.NumberOfPosts
            }));
            return models;
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
