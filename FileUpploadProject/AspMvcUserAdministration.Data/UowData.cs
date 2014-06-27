using System;
using System.Collections.Generic;
using FileUpload.Data;
using FileUpload.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FileUpload.Data
{


    public class UowData : IUowData
    {
        private class Key 
        {
            public Type TypeOfEntity { get; set; }
            public Type TypeOfIndex { get; set; }
        }

        private readonly DataContext context;
        private readonly Dictionary<Key, object> repositories = new Dictionary<Key, object>();

        public UowData()
            : this(new DataContext())
        {
        }

        public UowData(DataContext context)
        {
            this.context = context;
        }



        public IRepository<ApplicationUser,string> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser,string>();
            }
        }

        public IRepository<IdentityRole,string> Roles
        {
            get
            {
                return this.GetRepository<IdentityRole,string>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IRepository<T,I> GetRepository<T,I>() where T : class
        {
            var key = new Key() { TypeOfEntity = typeof(T), TypeOfIndex = typeof(I) };
            if (!this.repositories.ContainsKey(key))
            {
                var type = typeof(GenericRepository<T,I>);

                this.repositories.Add(key, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T,I>)this.repositories[key];
        }
    }
}
