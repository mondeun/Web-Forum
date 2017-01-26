using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Web_Forum.data.DTO;
using Web_Forum.data.Interfaces;
using Web_Forum.data.Models;

namespace Web_Forum.data.Repositories
{
    public class Repository : IRepository
    {
        public void AddPost(PostDTO post)
        {
            var newPost = new Post
            {
                Id = Guid.NewGuid(),
                Name = post.Name,
                Text = post.Text,
                Posted = DateTime.UtcNow,
                ThreadId = post.ThreadId
            };
            using (var ctx = new WebForumContext())
            {
                ctx.Posts.Add(newPost);
                ctx.SaveChanges();
            }
        }

        public void EditPost(PostDTO post)
        {
            using(var ctx = new WebForumContext())
            {
                var postToEdit = ctx.Posts.Find(post.Id);
                postToEdit.Text = post.Text;

                ctx.Entry(postToEdit).State = EntityState.Modified;
                ctx.SaveChanges();

            }
        }

        public void AddThread(ThreadDTO dto)
        {
            var newThread = new Thread
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                DateCreated = DateTime.UtcNow,
                LastPosted = DateTime.UtcNow,
                Likes = 0
            };

            var post = new Post
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Text = dto.Text,
                Posted = DateTime.UtcNow
            };

            newThread.Posts.Add(post);

            using (var ctx = new WebForumContext())
            {
                ctx.Threads.Add(newThread);
                ctx.SaveChanges();
            }
        }

        public void EditThread(IndexThreadDTO thread)
        {
            using(var ctx = new WebForumContext())
            {
                var threadToEdit = ctx.Threads.Find(thread.Id);

                threadToEdit.Title = thread.Title;
                ctx.Entry(threadToEdit).State = EntityState.Modified;
                ctx.SaveChanges();
                
            }
        }

        public List<PostDTO> GetPosts(Guid threadId)
        {
            var postsFromThreadId = new List<PostDTO>();
            using (var ctx = new WebForumContext())
            {
                var posts = ctx.Posts.Include("Thread").Where(x => x.Thread.Id == threadId).ToList();

                posts.ForEach(x => postsFromThreadId.Add(new PostDTO
                {
                    Id = x.Id,
                    ThreadId = x.Thread.Id,
                    Name = x.Name,
                    Text = x.Text,
                    Posted = x.Posted,
                    Likes = x.Likes
                }));
            }
            return postsFromThreadId;
        }

        public ThreadDTO GetThreadById(Guid id)
        {
            using (var ctx = new WebForumContext())
            {
                var thread = ctx.Threads.Include("Posts").FirstOrDefault(x => x.Id == id);

                var dto = new ThreadDTO
                {
                    Title = thread.Title,
                    // TODO Fill in rest
                };
                return dto;
            }
        }

        public List<IndexThreadDTO> GetThreads()
        {
            using ( var ctx = new WebForumContext())
            {
                var threads = ctx.Threads.Include("Posts").ToList();

                var dtos = new List<IndexThreadDTO>();
                threads.ForEach(x => dtos.Add(new IndexThreadDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    DateCreated = x.DateCreated,
                    LastPosted = x.Posts.Last().Posted,
                    NumberOfPosts = x.Posts.Count,
                    Likes = x.Likes
                }));

                return dtos;
            }
        }

        public List<PostDTO> GetPosts()
        {
            throw new NotImplementedException();
        }

        public int GetLikes(Guid threadId)
        {
            using (var ctx = new WebForumContext())
            {
                var thread = ctx.Threads.Find(threadId);

                return thread?.Likes ?? 0;
            }
        }
        public int UpdateLikes(Guid threadId)
        {
            var likesAmount = 0;
            using (var ctx = new WebForumContext())
            {
                var thread = ctx.Threads.Find(threadId);
                thread.Likes += 1;
                likesAmount = thread.Likes;
                ctx.Entry(thread).State = EntityState.Modified;

                ctx.SaveChanges();
            }
            return likesAmount;
        }
        public int GetPostLikes(Guid postId)
        {
            using (var ctx = new WebForumContext())
            {
                var post = ctx.Posts.Find(postId);

                return post?.Likes ?? 0;
            }
        }
        public int UpdatePostLikes(Guid postId)
        {
            var likesAmount = 0;
            using (var ctx = new WebForumContext())
            {
                var post = ctx.Posts.Find(postId);
                post.Likes += 1;
                likesAmount = post.Likes;
                ctx.Entry(post).State = EntityState.Modified;

                ctx.SaveChanges();
            }
            return likesAmount;
        }

        public List<IndexThreadDTO> SearchThreads(string search)
        {
            using (var ctx = new WebForumContext())
            {
                var threads = ctx.Threads.Include("Posts").Where(x => x.Title.Contains(search)).ToList();

                var dtos = new List<IndexThreadDTO>();
                threads.ForEach(x => dtos.Add(new IndexThreadDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    DateCreated = x.DateCreated,
                    LastPosted = x.Posts.Last().Posted,
                    NumberOfPosts = x.Posts.Count,
                    Likes = x.Likes
                }));

                return dtos;
            }
        }

        public List<PostDTO> SearchPosts(string search)
        {
            using (var ctx = new WebForumContext())
            {
                var posts = ctx.Posts.Include("Thread").Where(x => x.Text.Contains(search)).ToList();

                var dtos = new List<PostDTO>();
                posts.ForEach(x => dtos.Add(new PostDTO
                {
                    ThreadId = x.ThreadId,
                    Name = x.Name,
                    Text = x.Text,
                    Posted = x.Posted,
                    Likes = x.Likes
                }));

                return dtos;
            }
        }

        public UserDTO GetUserByCredentials(string email, string password)
        {
            using (var ctx = new WebForumContext())
            {
                var user = ctx.Users.FirstOrDefault(x => x.Email == email && x.Password == password) ?? new User();

                var dto = new UserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    IsModerator = user.IsModerator
                };

                return dto;
            }
        }
    }
}
