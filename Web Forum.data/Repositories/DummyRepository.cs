using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Forum.data.Interfaces;
using Web_Forum.data.Models;

namespace Web_Forum.data.Repositories
{
    class DummyRepository : IRepository
    {
        private List<Subforum> subForums;
        private List<Topic> topics;
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
                }
            };
            topics = new List<Topic>
            {
                new Topic {Id = Guid.NewGuid(), Title = "C#", Threads = threads}
            };
            subForums = new List<Subforum>
            {
                new Subforum {Id = Guid.NewGuid(), Title = "Programmering", Topics = topics}
            };
        }

        public List<Subforum> GetSubforums()
        {
            return subForums;
        }

        public List<Topic> GetTopics(Guid subForumId)
        {
            return topics;
        }

        public List<Thread> GetThreads(Guid topicId)
        {
            return threads;
        }

        public List<Post> GetPosts(Guid threadId)
        {
            return posts;
        }
    }
}
