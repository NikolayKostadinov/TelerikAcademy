namespace StudentsByGrade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UtilityClasses;

    public class Program
    {
        public static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student("Nikolay", "Kostadinov", 4.50f),
                new Student("Liubo", "Kolev", 3.20f),
                new Student("Svetla", "Stojanova", 5.50f),
                new Student("Svetlin", "Drumev", 4.00f),
                new Student("Magdalena", "Boianova", 4.50f),
                new Student("Mariana", "Grigorova", 3.20f),
                new Student("Svilen", "Boshnakov", 4.50f),
                new Student("Pencho", "Penchev", 2.50f),
                new Student("Maria", "Lefterova", 4.50f),
                new Student("Nikolay", "Zlatev", 6.00f),
            };

            List<Worker> workers = new List<Worker>
            {
                new Worker("Mili", "Vanili", 10m, 6),
                new Worker("Liubo", "Krumov", 20m, 4),
                new Worker("Svetla", "Kakova", 100m, 8),
                new Worker("Vechka", "Slaninkova", 200m, 6),
                new Worker("Pawlina", "Kostadinova", 300m, 7),
                new Worker("Zlatka", "Peneva", 400m, 8),
                new Worker("Svilen", "Boshnov", 400m, 6),
                new Worker("Penio", "Penchev", 300m, 3),
                new Worker("Penio", "Penev", 20m, 1),
                new Worker("Valentin", "Zlatev", 250m, 2),
            };

            var orderedStudentds = students.OrderBy(student => student.Grade);

            foreach (Student student in orderedStudentds)
            {
                student.WriteMe();
            }

            Console.WriteLine();
            var orderedWorkers = workers.OrderByDescending(worker => worker.MoneyPerHour());

            foreach (Worker worker in orderedWorkers)
            {
                worker.WriteMe();
            }

            Console.WriteLine();

            List<Human> humans = new List<Human>();

            humans.AddRange(orderedStudentds);
            humans.AddRange(orderedWorkers);

            var sortedHumans = 
                humans.OrderBy(human => human.FirstName)
                .ThenBy(human => human.LastName);

            foreach (Human human in sortedHumans) 
            {
                human.WriteMe();
            }
        }
    }
}
