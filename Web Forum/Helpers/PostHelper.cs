using System.Collections.Generic;
using System.Linq;
using Web_Forum.data.DTO;
using Web_Forum.Models;

namespace Web_Forum.Helpers
{
    public static class PostHelper
    {
        public static PostDTO Transform(PostViewModel post) => new PostDTO
        {
            Id = post.Id,
            ThreadId = post.ThreadId,
            Likes = post.Likes,
            Name = post.Name,
            Posted = post.Posted,
            Text = post.Text
        };

        public static List<PostViewModel> Transform(IEnumerable<PostDTO> dtos)
        {
            return dtos?.Select(x => new PostViewModel
            {
                Id = x.Id,
                ThreadId = x.ThreadId,
                Name = x.Name,
                Text = x.Text,
                Posted = x.Posted,
                Likes = x.Likes
            }).ToList();
        }
    }
}