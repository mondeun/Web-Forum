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
        List<Thread> GetThreads();
        List<Post> GetPosts(Guid threadId);
    }
}
