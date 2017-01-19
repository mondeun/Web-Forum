using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web_Forum.data.DTO;
using Web_Forum.data.Repositories;

namespace Web_Forum.test
{
    [TestClass]
    public class ThreadTest
    {
        [TestMethod]
        public void AddThread()
        {
            var repo = new DummyRepository();

            var dto = new ThreadDTO
            {
                Title = "Test",
                Name = "Adam",
                Text = "Hello"
            };

            Assert.AreEqual(3, repo.GetThreads().Count);
            repo.AddThread(dto);
            Assert.AreEqual(4, repo.GetThreads().Count);
        }
    }
}
