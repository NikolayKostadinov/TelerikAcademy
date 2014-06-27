using System;
using System.Data.Entity;
using System.Linq;
using FileUpload.Models;
using FileUpload.Models.FileModels;
using FileUpload.Models.FileModels.Mapping;
using FileUpload.Models.IdentityModels;
using FileUpload.Models.IdentityModels.Models;
using FileUpload.Models.IdentityModels.Models.Mapping;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FileUpload.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        //Here you can add you entities 
        //public virtual IDbSet<SomeModel> SomeModels {get; set;}

        public DataContext()
            : this("DefaultConnection")
        {
        }

        public DataContext(string connectionString)
            : base(connectionString, throwIfV1Schema: false)
        {
        }

        public static DataContext Create()
        {
            return new DataContext();
        }

        public IDbSet<AspNetRole> AspNetRoles { get; set; }
        public IDbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public IDbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public IDbSet<AspNetUser> AspNetUsers { get; set; }
        public IDbSet<FileDescription> FilesDesctiption { get; set; }
        public IDbSet<UploadResult> UploadResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AspNetRole>().HasKey(t => t.Id);
            modelBuilder.Entity<AspNetUserClaim>().HasKey(t => t.Id);
            modelBuilder.Entity<AspNetUserLogin>().HasKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            modelBuilder.Entity<AspNetUser>().HasKey(t => t.Id);
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new FileDescriptionMap());
        }
    }


}
