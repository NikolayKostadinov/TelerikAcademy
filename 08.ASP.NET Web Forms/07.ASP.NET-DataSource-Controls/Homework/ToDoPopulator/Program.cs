using System;
using System.Data.Entity;
using System.Linq;
using ToDoList.Data;
using ToDoList.Data.Models;

namespace ToDoPopulator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TodoListContext())
            {
                var category = new Category()
                {
                    Name = "Test",
                };
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
    }
}
