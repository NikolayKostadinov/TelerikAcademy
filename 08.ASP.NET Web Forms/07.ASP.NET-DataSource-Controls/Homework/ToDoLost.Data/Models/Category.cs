using System;
using System.Collections.Generic;

namespace ToDoLost.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Todos = new List<Todo>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Todo> Todos { get; set; }
    }
}
