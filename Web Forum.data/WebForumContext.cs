using Web_Forum.data.Models;
using System.Data.Entity;


namespace Web_Forum.data
{
    public class WebForumContext : DbContext
    {
        
        public DbSet<Post> Posts { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<User> Users { get; set; }

        public WebForumContext(): base("WebforumContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<WebForumContext>());
        }
    }
}
