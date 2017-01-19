using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Forum.data.Interfaces;
using Web_Forum.data.Models;

namespace Web_Forum.data.Repositories
{
    public class DummyRepository : IRepository
    {
        private List<Thread> threads;
        private List<Post> posts;

        public DummyRepository()
        {
            posts = new List<Post>
            {
                new Post {Id = Guid.NewGuid(), Name = "Harry", Posted = DateTime.UtcNow, Text = "Detta är ett test"},
                new Post {Id = Guid.NewGuid(), Name = "Glenn", Posted = DateTime.UtcNow, Text = "Några saker"}
            };
            threads = new List<Thread>
            {
                new Thread
                {
                    Id = Guid.NewGuid(),
                    Title = "Nu testar vi strukturen",
                    DateCreated = DateTime.UtcNow,
                    LastPosted = DateTime.UtcNow,
                    Posts = posts
                },
                new Thread
                {
                    Id = Guid.NewGuid(),
                    Title = "Nästa tråd",
                    DateCreated = DateTime.UtcNow,
                    LastPosted = DateTime.UtcNow,
                    Posts = posts
                },
                new Thread
                {
                    Id = Guid.NewGuid(),
                    Title = "Varför är Sture så lustig?",
                    DateCreated = DateTime.UtcNow,
                    LastPosted = DateTime.UtcNow,
                    Posts = posts
                }
            };
        }

        public void AddThread(Thread thread)
        {
            // TODO
        }

        public void AddPost(Post post)
        {
            // TODO
        }

        public List<Thread> GetThreads()
        {
            return threads;
        }

        public List<Post> GetPosts(Guid threadId)
        {
            return posts;
        }
    }
}
