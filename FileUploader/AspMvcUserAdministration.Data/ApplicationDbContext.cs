using System.Data.Common;
using System.Data.Entity;
using FileUpload.Data.Migrations;
using FileUpload.Models;
using FileUpload.Models.FileModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FileUpload.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //Here you can add you entities 
        //public virtual IDbSet<SomeModel> SomeModels {get; set;}
        public DbConnection Connection 
        {
            get 
            {
                return this.Database.Connection;
            } 
        }
        public virtual IDbSet<FileDescription> FileDescriptions { get; set; }
        public virtual IDbSet<UploadResult> UploadResults { get; set; }
        static ApplicationDbContext() 
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public ApplicationDbContext(string connectionString)
            : base(connectionString)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}