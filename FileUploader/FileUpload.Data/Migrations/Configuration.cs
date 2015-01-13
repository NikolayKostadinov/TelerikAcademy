namespace FileUpload.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FileUpload.Models.Identity;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<FileUpload.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "FileUpload.Data.ApplicationDbContext";

        }

        protected override void Seed(FileUpload.Data.ApplicationDbContext context)
        {
            var userMgr = new UserManager<ApplicationUser, int>(new UserStoreIntPk(context));
            var roleMgr = new RoleManager<RoleIntPk, int>(new RoleStoreIntPk(context));

            IList<string> roleNames = new List<string>() { "Administrator", "Upploader", "Exporter" };
            string userName = "Admin";
            string password = "12345678";
            string email = "support@bmsys.eu";

            foreach (string role in roleNames)
            {
                if (!roleMgr.RoleExists(role))
                {
                    roleMgr.Create(new RoleIntPk(role));
                }
            }

            var user = userMgr.FindByName(userName);
            
            if (user == null)
            {
                userMgr.Create<ApplicationUser,int>(new ApplicationUser { UserName = userName, Email = email }, password);
                user = userMgr.FindByName(userName);
            }

            if (!userMgr.IsInRole(user.Id, roleNames[0]))
            {
                userMgr.AddToRole(user.Id, roleNames[0]);
            }
        }
    }
}
