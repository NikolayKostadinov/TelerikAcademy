using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ToDoList.Data.Models.Mapping;

namespace ToDoList.Data.Models
{
    public partial class TodoListContext : DbContext
    {
        //static TodoListContext()
        //{
        //    Database.SetInitializer<TodoListContext>();
        //}

        public TodoListContext()
            : base("Name=TodoListContextWork")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new TodoMap());
        }
    }
}
