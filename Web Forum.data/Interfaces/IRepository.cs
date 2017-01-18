using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Forum.data.Models;

namespace Web_Forum.data.Interfaces
{
    public interface IRepository
    {
        List<Subforum> GetSubforums();
        List<Topic> GetTopics(Guid subForumId);
        List<Thread> GetThreads(Guid topicId);
        List<Post> GetPosts(Guid threadId);
    }
}
