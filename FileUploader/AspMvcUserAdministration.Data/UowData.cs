using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using FileUpload.Data;
using FileUpload.Models;
using FileUpload.Models.FileModels;
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

        private readonly ApplicationDbContext context;
        private readonly Dictionary<Key, object> repositories = new Dictionary<Key, object>();

        public UowData()
            : this(new ApplicationDbContext())
        {
        }

        public UowData(ApplicationDbContext context)
        {
            this.context = context;
        }



        public IRepository<ApplicationUser, string> Users
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

        /// <summary>
        /// Gets the file descriptions.
        /// </summary>
        /// <value>The file descriptions.</value>
        public IRepository<FileDescription,int> FileDescriptions
        {
            get
            {
                return this.GetRepository<FileDescription,int>();
            }
        }

        /// <summary>
        /// Gets the upload results.
        /// </summary>
        /// <value>The upload results.</value>
        public IRepository<UploadResult,int> UploadResults
        {
            get
            {
                return this.GetRepository<UploadResult,int>();
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

        private IRepository<T, I> GetRepository<T, I>() where T : class
        {
            var key = new Key() { TypeOfEntity = typeof(T), TypeOfIndex = typeof(I) };
            if (!this.repositories.ContainsKey(key))
            {
                Type type;
                if (!(typeof(T) == typeof(FileDescription)))
                {
                    type = typeof(GenericRepository<T, I>);
                }
                else
                {
                    type = typeof(FileDescriptionRepository);
                }
                

                this.repositories.Add(key, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T, I>)this.repositories[key];
        }
    }
}
