namespace Web_Forum.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
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
                        Thread_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Threads", t => t.Thread_Id)
                .Index(t => t.Thread_Id);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        LastPosted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Thread_Id", "dbo.Threads");
            DropIndex("dbo.Posts", new[] { "Thread_Id" });
            DropTable("dbo.Threads");
            DropTable("dbo.Posts");
        }
    }
}
