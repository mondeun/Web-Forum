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
        int  UpdateLikes(Guid Id);
        int GetPostLikes(Guid Id);
        int UpdatePostLikes(Guid Id);
        List<IndexThreadDTO> SearchThreads(string search);
        List<PostDTO> SearchPosts(string search);
        UserDTO GetUserByCredentials(string email, string password);
    }
}
