//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Manhattan Inc.">
//     Manhattan Inc.
// </copyright>
//-----------------------------------------------------------------------

namespace School
{
    using System;
    
    /// <summary>
    /// Main program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Method
        /// </summary>
        public static void Main()
        {
            School tmt = new School("TMT");
            Course electricalEngeneering = new Course("Electrical Enceneering");
            for (int i = 0; i < 10; i++)
            {
                electricalEngeneering.JoinCourse(new Student(string.Format("Student{0}", i), tmt.GetStugentId));                    
            }

            tmt.AddCourse(electricalEngeneering);

            ConsolePrinter(tmt.ToString());
            foreach (var course in tmt.ViewCourses())
            {
                ConsolePrinter(course.ToString(), 3);
                foreach (var student in course.ViewStudents())
                {
                    ConsolePrinter(student.Value.ToString(), 6);
                }
            }
        }

        private static void ConsolePrinter(string printed, int padding = 0)
        {
            string message = printed.PadLeft(printed.Length + padding);
            Console.WriteLine(message);
        }
    }
}
