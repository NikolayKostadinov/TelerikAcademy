namespace StudentsSystem.Data.Migrations
{
    using StudentsSystem.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentsSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

            ContextKey = "StudentsSystem.Data.StudentsSystemContext";
        }

        protected override void Seed(StudentsSystem.Data.StudentsSystemContext context)
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
            HashSet<Homework> homeworks = new HashSet<Homework>();
            Homework firstHomework = new Homework
            {
                HomeworkID = 1,
                CourseID = 1,
                Content = "RandomContent1",
                StudentID = 1,
                TimeSent = new DateTime(1997, 01, 01)
            };
            Homework secondHomework = new Homework
            {
                HomeworkID = 2,
                CourseID = 1,
                Content = "RandomContent2",
                StudentID = 1,
                TimeSent = new DateTime(1997, 01, 01)
            };
            homeworks.Add(firstHomework);
            homeworks.Add(secondHomework);
            Course css = new Course
            {
                CourseID = 1,
                Name = "CSS",
                Description = "Unknown",
                Materials = "Unknown",
                Homeworks = homeworks
            };

            Student pesho = new Student
            {
                StudentID = 1,
                FirstName = "Pesho",
                Number = "1234",
                Homeworks = homeworks,
                Courses = new HashSet<Course> { css },
                LastName = "Peshev"
            };
            css.Students = new HashSet<Student> { pesho };

            context.Students.AddOrUpdate(pesho);
            context.Courses.AddOrUpdate(css);
            context.Homeworks.AddOrUpdate(firstHomework, secondHomework);
        }
    }
}
