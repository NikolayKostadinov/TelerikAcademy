using System;
using FileUpload.Models.FileModels;
using FileUpload.Models.Identity;
using FileUpload.Models.LogModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FileUpload.Data
{
    public interface IUowData : IDisposable
    {
        //Here we have to register all the repositories which we use
        IRepository<ApplicationUser,int> Users { get; }
        IRepository<RoleIntPk, int> Roles { get; }
        IRepository<FileDescription,int> FileDescriptions { get; }
        IRepository<UploadResult,int> UploadResults { get; }
        IRepository<TraceLogMessage, int> TraceLogMessages { get; }
        int SaveChanges();
    }
}
