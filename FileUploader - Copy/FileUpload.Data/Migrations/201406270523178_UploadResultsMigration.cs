namespace FileUpload.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UploadResultsMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UploadResults", "RowNumber", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UploadResults", "RowNumber", c => c.String());
        }
    }
}
