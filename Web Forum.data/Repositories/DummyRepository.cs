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
                    Id = Guid.Parse("3cab7754-2836-466f-be16-da27e4ecb287"),
                    Title = "Nu testar vi strukturen",
                    DateCreated = DateTime.UtcNow,
                    LastPosted = DateTime.UtcNow,
                    Posts = posts.GetRange(0, 2)
                },
                new Thread
                {
                    Id = Guid.Parse("1895a78f-5e10-4757-8f69-cba9a691de0e"),
                    Title = "Semlor för hela slanten",
                    DateCreated = DateTime.UtcNow,
                    LastPosted = DateTime.UtcNow,
                    Posts = posts.GetRange(2, 1)
                },
                new Thread
                {
                    Id = Guid.Parse("1f820aad-3c43-4c74-bf8e-23940ca6f664"),
                    Title = "Tappat nycklar",
                    DateCreated = DateTime.UtcNow,
                    LastPosted = DateTime.UtcNow,
                    Posts = posts.GetRange(3, 3)
                }
            };
        }

        public void AddThread(ThreadDTO dto)
        {
            var thread = new Thread
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                DateCreated = DateTime.UtcNow,
                LastPosted = DateTime.UtcNow
            };

            var post = new Post
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Text = dto.Text,
                Posted = DateTime.UtcNow
            };

            thread.Posts.Add(post);

            threads.Add(thread);
            posts.Add(post);
        }

        public void AddPost(PostDTO dto)
        {
            var post = new Post
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Text = dto.Text,
                Posted = DateTime.UtcNow
            };

            GetThreadById(dto.ThreadId).Posts.Add(post);
        }

        public List<Thread> GetThreads()
        {
            return threads;
        }

        public Thread GetThreadById(Guid id)
        {
            var result = new Thread();
            foreach (var thread in threads)
            {
                if (thread.Id == id)
                    result = thread;
            }

            return result;
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

        List<IndexThreadDTO> IRepository.GetThreads()
        {
            throw new NotImplementedException();
        }

        ThreadDTO IRepository.GetThreadById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<PostDTO> GetPosts()
        {
            throw new NotImplementedException();
        }

        List<PostDTO> IRepository.GetPosts(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
