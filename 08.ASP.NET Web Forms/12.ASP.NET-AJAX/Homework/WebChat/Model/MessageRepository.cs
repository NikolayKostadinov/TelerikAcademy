using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat
{
    public class MessageRepository : IRepository
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Message> GetAll()
        {
            var contex = new MessageContext();
            var messages = contex.Messages.OrderByDescending(t => t.MessageId).Take(100).OrderBy(t => t.MessageId);
            return messages;
        }

        /// <summary>
        /// Inserts the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public void Insert(Message msg)
        {
            using (var contex = new MessageContext())
            {
                contex.Messages.Add(msg);
                contex.SaveChanges();
            }
        }
    }
}