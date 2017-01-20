using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Forum.data.Models;
using System.Data.Entity;

namespace Web_Forum.data
{
    public class WebForumContext : DbContext
    {
        
        public DbSet<Post> Posts { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public WebForumContext(): base("WebforumContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<WebForumContext>());
        }
    }
}
