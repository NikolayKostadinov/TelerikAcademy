namespace FileUpload.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TracelogMessageMapRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TraceLogMessages", "Controller", c => c.String(nullable: false));
            AlterColumn("dbo.TraceLogMessages", "Action", c => c.String(nullable: false));
            AlterColumn("dbo.TraceLogMessages", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TraceLogMessages", "Message", c => c.String());
            AlterColumn("dbo.TraceLogMessages", "Action", c => c.String());
            AlterColumn("dbo.TraceLogMessages", "Controller", c => c.String());
        }
    }
}
