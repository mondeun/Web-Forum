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
        List<IndexThreadDTO> GetThreads();
        IndexThreadDTO GetThreadById(Guid id);
        List<PostDTO> GetPosts();
        List<PostDTO> GetPosts(Guid id);
        int GetLikes(Guid id);
        int  UpdateLikes(Guid id);
        int GetPostLikes(Guid id);
        int UpdatePostLikes(Guid id);
        List<IndexThreadDTO> SearchThreads(string search);
        List<PostDTO> SearchPosts(string search);
        UserDTO GetUserByCredentials(string email, string password);
    }
}
