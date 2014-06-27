using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUpload.Models.FileModels;
using System.Data.Entity.Infrastructure;

namespace FileUpload.Data
{
    class FileDescriptionRepository:IRepository<FileDescription,int>
    {
        public FileDescriptionRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<FileDescription>();
        }

        protected IDbSet<FileDescription> DbSet { get; set; }

        protected DbContext Context { get; set; }

        public virtual IQueryable<FileDescription> All()
        {
            return this.DbSet.Include("ApplicationUser").AsQueryable();
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public FileDescription GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(FileDescription entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public virtual void Update(FileDescription entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(FileDescription entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Detach(FileDescription entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }
        /// <summary>
        /// Bulks the insert.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void BulkInsert(IEnumerable<FileDescription> entities)
        {
            ((DbSet<FileDescription>)this.DbSet).AddRange(entities);
        }
    }
}
