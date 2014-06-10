using System;
using System.Linq;
using AspMvcUserAdministration.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspMvcUserAdministration.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        //Here you can add you entities 
        //public virtual IDbSet<SomeModel> SomeModels {get; set;}
        public DataContext() : this("DefaultConnection")
        {
        }

        public DataContext(string connectionString) : base(connectionString) 
        { 
        }
    }


}
