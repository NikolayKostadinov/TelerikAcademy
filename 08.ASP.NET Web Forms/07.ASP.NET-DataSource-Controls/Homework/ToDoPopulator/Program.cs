using System;
using System.Data.Entity;
using System.Linq;
using ToDoLost.Data;
using ToDoLost.Data.Models;

namespace ToDoPopulator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ToDoLost.Data.Models.TodoListContext())
            {
                //context.Entry(context.Todos).State = EntityState.Modified;
                //context.Entry(context.Categories).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
