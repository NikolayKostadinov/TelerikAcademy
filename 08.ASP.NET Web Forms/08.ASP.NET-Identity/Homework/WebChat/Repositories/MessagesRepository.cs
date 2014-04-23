using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using WebChat.Models;

namespace WebChat.Repositories
{
    public class MessagesRepository : IRepository<ChatMessage>
    {

        public MessagesRepository()
        {
            this.Context = new ApplicationDbContext();
            this.DbSet = this.Context.Set<ChatMessage>();
        }

        protected IDbSet<ChatMessage> DbSet { get; set; }

        protected DbContext Context { get; set; }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns></returns>
        public ICollection<ChatMessage> All()
        {
            return this.DbSet.Include("User").ToList();
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="Id">The id.</param>
        /// <returns></returns>
        public ChatMessage GetById(int Id)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the new.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddNew(ChatMessage item)
        {
            DbEntityEntry entry = this.Context.Entry(item);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                item = this.DbSet.Add(item);
            }

            this.Context.SaveChanges();
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Update(ChatMessage item)
        {
            DbEntityEntry entry = this.Context.Entry(item);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(item);
            }

            entry.State = EntityState.Modified;

            this.Context.SaveChanges();
        }

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public void Delete(ChatMessage entity)
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

            this.Context.SaveChanges();
        }

        
       
    }
}