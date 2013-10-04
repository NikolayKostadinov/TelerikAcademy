namespace Tests
{
    using System;
    using Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Student;
using System.Timers;

    [TestClass]
    public class LinqTests
    {
        private static readonly Student[] Students;

        static LinqTests()
        {
            Students = new Student[] 
                { 
                    new Student { FirstName = "Ivan", LastName = "Ivanov", Age = 10 },
                    new Student { FirstName = "Georgi",  LastName = "Popov", Age = 50 },
                    new Student { FirstName = "Georgi",  LastName = "Simeonov", Age = 12 },
                    new Student { FirstName = "Ivan",  LastName = "Todorov", Age = 18 },
                    new Student { FirstName = "Petar",  LastName = "Chipev", Age = 19 },
                    new Student { FirstName = "Anton",  LastName = "Donchev", Age = 24 },
                    new Student { FirstName = "Filip",  LastName = "Andreev", Age = 26 },
                    new Student { FirstName = "Svetslav",  LastName = "Bozov", Age = 28 },
                };
        }
       
        [TestMethod]
        public void FindAllStudentTest1()
        {
            var result = Linq.FindAllStudents(Students);
            foreach (Student item in result)
            {
                Console.WriteLine("{0,-15} {1,15}", item.FirstName, item.LastName);   
            }  
        }

        [TestMethod]
        public void FindAllStudentsByAgeTest1() 
        {
            string[] result = Linq.FindAllStudentsByAge(Students);
            
            foreach (string item in result)
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod]
        public void SortStudentsByNameAndLastNameTest1()
        {
            Student[] result = Linq.SortStudentsByNameAndLastName1(Students);
            Student[] result1 = Linq.SortStudentsByNameAndLastName2(Students);

            foreach (Student item in result)
            {
                Console.WriteLine("{0,-15} {1,15}", item.FirstName, item.LastName); 
            }

            Console.WriteLine();

            foreach (Student item in result1)
            {
                Console.WriteLine("{0,-15} {1,15}", item.FirstName, item.LastName);
            }

            bool aserttion = true;

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].FirstName != result[i].FirstName &&
                    result[i].LastName != result1[i].LastName)
                {
                    aserttion = false;
                }
            }

            Assert.AreEqual(aserttion, true, "Error in Sortiong");
        }
    }
}