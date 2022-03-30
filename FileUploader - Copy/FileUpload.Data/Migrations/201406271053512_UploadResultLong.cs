namespace FileUpload.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UploadResultLong : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UploadResults", "Status", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UploadResults", "Status", c => c.Int(nullable: false));
        }
    }
}