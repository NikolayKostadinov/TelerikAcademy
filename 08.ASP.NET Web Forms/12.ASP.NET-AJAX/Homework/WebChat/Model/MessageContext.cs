using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebChat
{
    public class MessageContext:DbContext
    {
        public MessageContext():base("MessageConnection")
        { 
        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>().HasKey(t => t.MessageId);
            modelBuilder.Entity<Message>().Property(t => t.MessageText).IsUnicode(true);
        }
    }
}