namespace StudentsSystem.ConsoleDemo
{
    using StudentsSystem.Data;
    using StudentsSystem.Data.Migrations;
    using StudentsSystem.Model;
    using System;
    using System.Data.Entity;

    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemContext, Configuration>());
            
            using (StudentsSystemContext dbContext = new StudentsSystemContext())
            {
                var firstHomework = new Homework()
                {
                    Content = "Simple database1",
                    TimeSent = DateTime.Now,
                };

                var secondHomework = new Homework()
                {
                    Content = "Simple database2",
                    TimeSent = DateTime.Now,
                };

                var student = new Student()
                {
                    FirstName = "Nikolay",
                    LastName = "Kostadinov",
                    Number = "965552",
                };

                var course = new Course()
                {
                    Name = "DataBase",
                    Description = "Entity Framework Code First",
                    Materials = "Lections, homework"
                };

                student.Homeworks.Add(firstHomework);
                student.Homeworks.Add(secondHomework);
                student.Courses.Add(course);
                course.Homeworks.Add(secondHomework);
                course.Students.Add(student);

                dbContext.Students.Add(student);
                dbContext.Courses.Add(course);
                dbContext.Homeworks.Add(firstHomework);
                dbContext.Homeworks.Add(secondHomework);

                dbContext.SaveChanges();
            }
        }
    }
}
