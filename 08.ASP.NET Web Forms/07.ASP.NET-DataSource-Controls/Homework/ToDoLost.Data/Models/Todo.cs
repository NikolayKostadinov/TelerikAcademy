using System;
using System.Collections.Generic;

namespace ToDoList.Data.Models
{
    public partial class Todo
    {
        public int TodoId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Boby { get; set; }
        public Nullable<System.DateTime> DateOfLastChange { get; set; }
        public virtual Category Category { get; set; }
    }
}
