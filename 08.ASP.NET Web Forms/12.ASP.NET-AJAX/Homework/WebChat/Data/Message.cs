using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat
{
    public class Message
    {
        public int MessageId { get; set; }
        public DateTime MessageDateTime { get; set; }
        public string MessageText { get; set; }
    }
}