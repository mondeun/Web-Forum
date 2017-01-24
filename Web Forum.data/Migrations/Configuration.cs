using Web_Forum.data.Models;

namespace Web_Forum.data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Web_Forum.data.WebForumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Web_Forum.data.WebForumContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

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
                    ThreadId = Guid.Parse("3cab7754-2836-466f-be16-da27e4ecb287")
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Name = "Glenn",
                    Posted = DateTime.UtcNow,
                    Text = "Några saker",
                    ThreadId = Guid.Parse("3cab7754-2836-466f-be16-da27e4ecb287")
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Name = "Gustav",
                    Posted = DateTime.UtcNow,
                    Text = "Snart är det dags för semlor!!!",
                    ThreadId = Guid.Parse("1895a78f-5e10-4757-8f69-cba9a691de0e")
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Name = "Primadonna",
                    Posted = DateTime.UtcNow,
                    Text = "Glömde bort mina nycklar på bussen. HJÄLP!",
                    ThreadId = Guid.Parse("1f820aad-3c43-4c74-bf8e-23940ca6f664")
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Name = "Glenn",
                    Posted = DateTime.UtcNow,
                    Text = "Haha",
                    ThreadId = Guid.Parse("1f820aad-3c43-4c74-bf8e-23940ca6f664")
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Name = "Anonym",
                    Posted = DateTime.UtcNow,
                    Text = "Tack för nycklarna!",
                    ThreadId = Guid.Parse("1f820aad-3c43-4c74-bf8e-23940ca6f664")
                }
            );
        }
    }
}
