using System;
using FileUpload.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FileUpload.Data
{
    public interface IUowData : IDisposable
    {
        //Here we have to register all the repositories which we use
        IRepository<ApplicationUser,string> Users { get; }
        IRepository<IdentityRole,string> Roles { get; }

        int SaveChanges();
    }
}
