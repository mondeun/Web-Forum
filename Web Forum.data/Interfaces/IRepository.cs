using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Forum.data.DTO;
using Web_Forum.data.Models;

namespace Web_Forum.data.Interfaces
{
    public interface IRepository
    {
        void AddThread(ThreadDTO dto);
        void AddPost(PostDTO post);
        List<Thread> GetThreads();
        Thread GetThreadById(Guid id);
        List<Post> GetPosts(Guid threadId);
    }
}
