using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web_Forum.data.DTO;
using Web_Forum.data.Repositories;

namespace Web_Forum.test
{
    [TestClass]
    public class DataTest
    {
        //[TestMethod]
        //public void AddThread()
        //{
        //    var repo = new DummyRepository();

        //    var dto = new ThreadDTO
        //    {
        //        Title = "Test",
        //        Name = "Adam",
        //        Text = "Hello"
        //    };

        //    Assert.AreEqual(3, repo.GetThreads().Count);
        //    repo.AddThread(dto);
        //    Assert.AreEqual(4, repo.GetThreads().Count);
        //}

        //[TestMethod]
        //public void AddPost()
        //{
        //    var repo = new DummyRepository();
        //    var dto = new PostDTO
        //    {
        //        ThreadId = Guid.Parse("1895a78f-5e10-4757-8f69-cba9a691de0e"),
        //        Name = "Johan",
        //        Text = "Godmnorgon"
        //    };

        //    Assert.AreEqual(1, repo.GetPosts(dto.ThreadId).Count);
        //    repo.AddPost(dto);
        //    Assert.AreEqual(2, repo.GetPosts(dto.ThreadId).Count);
        //}
    }
}
