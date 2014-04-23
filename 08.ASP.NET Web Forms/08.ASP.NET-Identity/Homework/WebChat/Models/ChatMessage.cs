using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebChat.Models
{
    public class ChatMessage
    {
        public int MessageId { get; set; }
        public DateTime MessageDateTime { get; set; }

        public string MessageText { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}