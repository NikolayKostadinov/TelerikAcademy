namespace Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Student;

    public static class Linq
    {
        // Write a method that from a given array of students finds all 
        // students whose first name is before its last name alphabetically. Use LINQ query operators.
        public static Student[] FindAllStudents(Student[] students)
        {
            IEnumerable<Student> result =
                from st in students
                where st.FirstName.CompareTo(st.LastName) == -1
                select st;
            return result.ToArray();
        }

        // Write a LINQ query that finds the first name and last name of all students 
        // with age between 18 and 24. 
        public static string[] FindAllStudentsByAge(Student[] students)
        {
            IEnumerable<string> result =
                from st in students
                where (st.Age >= 18 && st.Age <= 24)
                select (st.FirstName + " " + st.LastName);
            return result.ToArray();
        }

        // Using the extension methods OrderBy() and ThenBy() with lambda expressions 
        // sort the students by first name and last name in descending order. Rewrite 
        // the same with LINQ.
        public static Student[] SortStudentsByNameAndLastName1(Student[] students) 
        {
            IEnumerable<Student> result = 
                students.OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName);            
            return result.ToArray(); 
        }

        // Using the extension methods OrderBy() and ThenBy() with lambda expressions 
        // sort the students by first name and last name in descending order. Rewrite 
        // the same with LINQ.
        public static Student[] SortStudentsByNameAndLastName2(Student[] students)
        {
            IEnumerable<Student> rs =
                from s in students
                orderby s.FirstName descending, s.LastName descending
                select s;

            return rs.ToArray();
        }
    }
}