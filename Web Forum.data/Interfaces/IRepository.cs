using System;
using System.Collections.Generic;
using Web_Forum.data.DTO;

namespace Web_Forum.data.Interfaces
{
    public interface IRepository
    {
        void AddThread(ThreadDTO dto);
        void AddPost(PostDTO dto);
        List<IndexThreadDTO> GetThreads();
        ThreadDTO GetThreadById(Guid id);
        List<PostDTO> GetPosts();
        List<PostDTO> GetPosts(Guid id);
        int GetLikes(Guid id);
        void UpdateLikes(Guid threadId);
        List<IndexThreadDTO> SearchThreads(string search);
        List<PostDTO> SearchPosts(string search);
    }
}
