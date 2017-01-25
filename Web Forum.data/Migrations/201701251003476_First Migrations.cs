namespace Web_Forum.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Text = c.String(),
                        Posted = c.DateTime(nullable: false),
                        ThreadId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Threads", t => t.ThreadId, cascadeDelete: true)
                .Index(t => t.ThreadId);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        LastPosted = c.DateTime(nullable: false),
                        Likes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsModerator = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "ThreadId", "dbo.Threads");
            DropIndex("dbo.Posts", new[] { "ThreadId" });
            DropTable("dbo.Users");
            DropTable("dbo.Threads");
            DropTable("dbo.Posts");
        }
    }
}
