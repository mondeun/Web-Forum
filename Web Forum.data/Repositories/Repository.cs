﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Posted = DateTime.UtcNow
            };
            using (var ctx = new WebForumContext())
            {
                ctx.Posts.Add(newPost);
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
                LastPosted = DateTime.UtcNow
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

        public List<PostDTO> GetPosts(Guid threadId)
        {
            var postsFromThreadId = new List<PostDTO>();
            using (var ctx = new WebForumContext())
            {
                var posts = ctx.Posts.Where(x => x.Thread.Id == threadId).ToList();

                posts.ForEach(x => postsFromThreadId.Add(new PostDTO
                {
                    ThreadId = x.Thread.Id,
                    Name = x.Name,
                    Text = x.Text
                }));
            }
            return postsFromThreadId;
        }

        public ThreadDTO GetThreadById(Guid id)
        {
            var thread = new Thread();
            using (var ctx = new WebForumContext())
            {
                thread = ctx.Threads.Include("Post").FirstOrDefault(x => x.Id == id);
            }

            var dto = new ThreadDTO();

            return dto;
        }

        public List<IndexThreadDTO> GetThreads()
        {
            using (var ctx = new WebForumContext())
            {
                var threads = ctx.Threads.Include("Post").ToList();

                var dtos = new List<IndexThreadDTO>();
                threads.ForEach(x => dtos.Add(new IndexThreadDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    DateCreated = x.DateCreated,
                    LastPosted = x.Posts.Last().Posted,
                    NumberOfPosts = x.Posts.Count
                }));

                return dtos;
            }
        }

        public List<PostDTO> GetPosts()
        {
            throw new NotImplementedException();
        }
    }
}
