namespace WebChat.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebChat.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WebChat.Models.ApplicationDbContext context)
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
            context.Roles.AddOrUpdate(
                p => p.Name,
                new ApplicationRole
                {
                    Name = "Administrator",
                    Description = "role, which can post, edit and delete all the posted content"
                },
                new ApplicationRole
                {
                    Name = "Moderator",
                    Description = "role, which can post and edit all the posted content"
                },
                new ApplicationRole
                {
                    Name = "RegisteredUser",
                    Description = "role can only post (create) a message"
                });
        }
    }
}