using System;
using AspMvcUserAdministration.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspMvcUserAdministration.Data
{
    public interface IUowData : IDisposable
    {
        //Here we have to register all the repositories which we use
        IRepository<ApplicationUser> Users { get; }
        IRepository<IdentityRole> Roles { get; }

        int SaveChanges();
    }
}
