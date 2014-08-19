using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FileUpload.Data.Mapping;
using FileUpload.Data.Migrations;
using FileUpload.Models.FileModels;
using FileUpload.Models.Identity;
using FileUpload.Models.LogModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FileUpload.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, RoleIntPk, int,
        UserLoginIntPk, UserRoleIntPk, UserClaimIntPk>
    {
        public virtual DbSet<FileDescription> FileDescriptions { get; set; }
        public virtual DbSet<UploadResult> UploadResults { get; set; }
        public virtual DbSet<TraceLogMessage> TraceLogMessages { get; set; }
 
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FileDescriptionMap());
            modelBuilder.Configurations.Add(new TraceLogMessageMap());
            modelBuilder.Conventions.Remove<IndexAttributeConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}