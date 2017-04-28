using System;
using System.Collections.Generic;
using Web_Forum.data.DTO;

namespace Web_Forum.data.Interfaces
{
    public interface IRepository
    {
        void AddThread(ThreadDTO dto);
        void AddPost(PostDTO dto);
        void EditThread(IndexThreadDTO thread);
        void EditPost(PostDTO post);
        void DeleteThread(Guid threadId);
        void DeletePost(Guid postId);
        IEnumerable<IndexThreadDTO> GetThreads();
        IndexThreadDTO GetThreadById(Guid id);
        IEnumerable<PostDTO> GetPosts();
        IEnumerable<PostDTO> GetPosts(Guid id);
        int GetLikes(Guid id);
        int UpdateLikes(Guid id);
        int UpdatePostLikes(Guid id);
        IEnumerable<IndexThreadDTO> SearchThreads(string search);
        IEnumerable<PostDTO> SearchPosts(string search);
        UserDTO GetUserByCredentials(string email, string password);
    }
}
