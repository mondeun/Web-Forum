using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Forum.data.DTO;
using Web_Forum.data.Interfaces;
using Web_Forum.data.Models;

namespace Web_Forum.data.Repositories
{
    public class Repository : IRepository
    {
        public void AddPost(PostDTO post)
        {
            var newPost = new Post
            {
                Id = Guid.NewGuid(),
                Name = post.Name,
                Text = post.Text,
                Posted = DateTime.UtcNow
            };
            using (var ctx = new WebForumContext())
            {
                ctx.Posts.Add(newPost);
                ctx.SaveChanges();
            }
        }
        public void AddThread(ThreadDTO dto)
        {
            var newThread = new Thread
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,

            };
            var post = new Post
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Text = dto.Text,
                Posted = DateTime.UtcNow
            };
            using (var ctx = new WebForumContext())
            {
                ctx.Posts.Add(post);
                ctx.Threads.Add(newThread);
                ctx.SaveChanges();
            }
        }

        public List<Post> GetPosts(Guid threadId)
        {
            var postsFromThreadId = new List<Post>();
            using (var ctx = new WebForumContext())
            {
                postsFromThreadId = ctx.Posts.Where(x => x.Thread.Id == threadId).ToList();
            }
            return postsFromThreadId;
        }

        public Thread GetThreadById(Guid id)
        {
            var thread = new Thread();
            using (var ctx = new WebForumContext())
            {
                
                thread = ctx.Threads.FirstOrDefault(x => x.Id == id);
            }
            return thread;
        }

        public List<Thread> GetThreads()
        {

            using (var ctx = new WebForumContext())
            {
                return ctx.Threads.ToList();
            }
        }
    }
}
