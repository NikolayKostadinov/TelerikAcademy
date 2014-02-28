using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SchoolSystem.Data;
using SchoolSystem.Data.Migrations;
using SchoolSystem.Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolContext,Configuration>());

            using (var context = new SchoolContext())
            {
                var school = new School() { Name = "Techical University Of Varna", Location = "Varna" };
                context.Schools.Add(school);
                context.SaveChanges();
            }
        }
    }
}
