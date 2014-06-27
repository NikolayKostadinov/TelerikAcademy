using System;
using FileUpload.Models;
using FileUpload.Models.FileModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FileUpload.Data
{
    public interface IUowData : IDisposable
    {
        //Here we have to register all the repositories which we use
        IRepository<ApplicationUser,string> Users { get; }
        IRepository<IdentityRole,string> Roles { get; }
        IRepository<FileDescription,int> FileDescriptions { get; }
        IRepository<UploadResult,int> UploadResults { get; }
        int SaveChanges();
    }
}
