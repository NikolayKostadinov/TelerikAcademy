namespace ToDoLost.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ToDoLost.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ToDoLost.Data.Models.TodoListContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ToDoLost.Data.Models.TodoListContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            ICollection<Todo> todos = new List<Todo>()
            {
                new Todo(){Title = "First Todo", Boby = "My first created todo.", DateOfLastChange=DateTime.Now},
                new Todo(){Title = "Pepi's pregnacy", Boby = "We are going to doctor to confirm Pepi's pregnacy. I realy hope that this time we will have a boy.", DateOfLastChange=DateTime.Now}
            };

            ICollection<Category> categories= new List<Category>(){ new Category {Name = "Urgent"}};

            context.Categories.AddOrUpdate(
                c => c,
                new Category {Name = "Urgent", Todos = todos}
                );
            context.Todos.AddOrUpdate(t=>t, todos.ToArray());
            context.SaveChanges();
        }
    }
}
