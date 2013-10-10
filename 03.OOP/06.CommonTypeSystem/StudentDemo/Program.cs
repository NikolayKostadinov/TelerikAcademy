namespace StudentDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using StudentCommon;

    public class Program
    {
        public static void Main()
        {
            List<Student> studentList = new List<Student>() 
            {
             new Student("Nikolay", "Dimitrov", "Kostadinov", "7711240547"),
             new Student("Stoyan", "Ivanov", "Petrov", "8506148485", "Maria Luiza N25", "0885698651", "stoyanpet@abv.bg", (short)2, Specialties.ETM, Universities.TUV, Faculties.FE),
             new Student("Stoyan", "Ivanov", "Petrov", "7608128816"),
             new Student("Ivan", "Ivanov", "Georgiev", "9608152138")
             };

            studentList.Sort();

            foreach (var item in studentList)
            {
                Console.WriteLine(item);
            }

            Student baseStudent = new Student(
                "Stoyan", 
                "Ivanov", 
                "Petrov", 
                "8506148485", 
                "Maria Luiza N25", 
                "0885698651",
                "stoyanpet@abv.bg", 
                (short)2, 
                Specialties.ETM, 
                Universities.TUV, 
                Faculties.FE);
            Student newStudent = baseStudent.Clone();

            Console.WriteLine(studentList[1].GetHashCode() + "  --  " + newStudent.GetHashCode() + " => " + studentList[1].GetHashCode().Equals(newStudent.GetHashCode()));
            Console.WriteLine(studentList[1].Equals(newStudent));
        }
    }
}
