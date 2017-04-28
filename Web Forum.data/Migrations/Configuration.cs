using Web_Forum.data.Models;

namespace Web_Forum.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<WebForumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebForumContext context)
        {
            context.Threads.AddOrUpdate(x => x.Id,
                new Thread
                {
                    Id = Guid.Parse("3cab7754-2836-466f-be16-da27e4ecb287"),
                    Title = "Nu testar vi strukturen",
                    DateCreated = DateTime.UtcNow,
                    LastPosted = DateTime.UtcNow,
                    Likes = 1
                },
                new Thread
                {
                    Id = Guid.Parse("1895a78f-5e10-4757-8f69-cba9a691de0e"),
                    Title = "Semlor för hela slanten",
                    DateCreated = DateTime.UtcNow,
                    LastPosted = DateTime.UtcNow,
                    Likes = 24
                },
                new Thread
                {
                    Id = Guid.Parse("1f820aad-3c43-4c74-bf8e-23940ca6f664"),
                    Title = "Tappat nycklar",
                    DateCreated = DateTime.UtcNow,
                    LastPosted = DateTime.UtcNow,
                    Likes = 479
                }
            );

            context.Posts.AddOrUpdate(x => x.Id,
                new Post
                {
                    Id = Guid.NewGuid(),
                    Name = "Harry",
                    Posted = DateTime.UtcNow,
                    Text = "Detta är ett test",
                    ThreadId = Guid.Parse("3cab7754-2836-466f-be16-da27e4ecb287"),
                    Likes = 50
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Name = "Glenn",
                    Posted = DateTime.UtcNow,
                    Text = "Några saker",
                    ThreadId = Guid.Parse("3cab7754-2836-466f-be16-da27e4ecb287"),
                    Likes = 40
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Name = "Gustav",
                    Posted = DateTime.UtcNow,
                    Text = "Snart är det dags för semlor!!!",
                    ThreadId = Guid.Parse("1895a78f-5e10-4757-8f69-cba9a691de0e"),
                    Likes = 15
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Name = "Primadonna",
                    Posted = DateTime.UtcNow,
                    Text = "Glömde bort mina nycklar på bussen. HJÄLP!",
                    ThreadId = Guid.Parse("1f820aad-3c43-4c74-bf8e-23940ca6f664"),
                    Likes = 9
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Name = "Glenn",
                    Posted = DateTime.UtcNow,
                    Text = "Haha",
                    ThreadId = Guid.Parse("1f820aad-3c43-4c74-bf8e-23940ca6f664"),
                    Likes = 16
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Name = "Anonym",
                    Posted = DateTime.UtcNow,
                    Text = "Tack för nycklarna!",
                    ThreadId = Guid.Parse("1f820aad-3c43-4c74-bf8e-23940ca6f664"),
                    Likes = 85
                }
            );

            context.Users.AddOrUpdate(x => x.Id,
                new User
                {
                    Id = Guid.Parse("1f820aad-3c43-4c74-bf8e-23940ca65564"),
                    Name = "Emilio Estevez",
                    Email = "cool_cat46@hotmail.com",
                    Password = "qwerty",
                    IsModerator = true
                }
            );
        }
    }
}
