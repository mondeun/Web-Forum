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
    public class DummyRepository : IRepository
    {
        private List<Thread> threads;
        private List<Post> posts;

        public DummyRepository()
        {
            posts = new List<Post>
            {
                new Post {Id = Guid.NewGuid(), Name = "Harry", Posted = DateTime.UtcNow, Text = "Detta är ett test"},
                new Post {Id = Guid.NewGuid(), Name = "Glenn", Posted = DateTime.UtcNow, Text = "Några saker"},
                new Post {Id = Guid.NewGuid(), Name = "Gustav", Posted = DateTime.UtcNow, Text = "Snart är det dags för semlor!!!"},
                new Post {Id = Guid.NewGuid(), Name = "Primadonna", Posted = DateTime.UtcNow, Text = "Glömde bort mina nycklar på bussen. HJÄLP!"},
                new Post {Id = Guid.NewGuid(), Name = "Glenn", Posted = DateTime.UtcNow, Text = "Haha"},
                new Post {Id = Guid.NewGuid(), Name = "Anonym", Posted = DateTime.UtcNow, Text = "Tack för nycklarna!"}
            };
            threads = new List<Thread>
            {
                new Thread
                {
                    Id = Guid.NewGuid(),
                    Title = "Nu testar vi strukturen",
                    DateCreated = DateTime.UtcNow,
                    LastPosted = DateTime.UtcNow,
                    Posts = posts.GetRange(0, 2)
                },
                new Thread
                {
                    Id = Guid.NewGuid(),
                    Title = "Semlor för hela slanten",
                    DateCreated = DateTime.UtcNow,
                    LastPosted = DateTime.UtcNow,
                    Posts = posts.GetRange(2, 1)
                },
                new Thread
                {
                    Id = Guid.NewGuid(),
                    Title = "Tappat nycklar",
                    DateCreated = DateTime.UtcNow,
                    LastPosted = DateTime.UtcNow,
                    Posts = posts.GetRange(3, 3)
                }
            };
        }

        public void AddThread(ThreadDTO dto)
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
            var posts = new List<Post>();
            foreach (var thread in threads)
            {
                if (thread.Id == threadId)
                {
                    posts.AddRange(thread.Posts);
                }
            }

            return posts;
        }
    }
}
