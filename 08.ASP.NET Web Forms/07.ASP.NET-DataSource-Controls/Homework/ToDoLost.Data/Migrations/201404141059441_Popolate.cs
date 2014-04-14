namespace ToDoLost.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Popolate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Todos",
                c => new
                    {
                        TodoId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Boby = c.String(),
                        DateOfLastChange = c.DateTime(),
                    })
                .PrimaryKey(t => t.TodoId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todos", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Todos", new[] { "CategoryId" });
            DropTable("dbo.Todos");
            DropTable("dbo.Categories");
        }
    }
}
