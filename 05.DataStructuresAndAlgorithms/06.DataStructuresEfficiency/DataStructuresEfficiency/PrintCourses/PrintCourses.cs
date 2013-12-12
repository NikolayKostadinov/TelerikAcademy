namespace PrintCourses
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Wintellect.PowerCollections;
    
    class PrintCourses
    {
        static void Main()
        {
            SortedDictionary<string, OrderedBag<Student>> courses = GetCoutsesFromFile("students.txt");
            
            foreach (var course in courses)
            {
                Console.Write("{0}: ", course.Key);

                string output = string.Join(",", course.Value);

                Console.WriteLine(output);
            }
        }

        private static SortedDictionary<string, OrderedBag<Student>> GetCoutsesFromFile(string fileName)
        {
            var courses = new SortedDictionary<string, OrderedBag<Student>>();

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File" + fileName + " not found!!!");
            }

            using (StreamReader inStream = new StreamReader(fileName, System.Text.Encoding.GetEncoding("windows-1251")))
            {
                while (inStream.Peek() >= 0)
                {
                    string record = inStream.ReadLine();
                    TransformStringToRecford(record, courses);
                }
            }
            return courses;
        }

        private static void TransformStringToRecford(string record, SortedDictionary<string, OrderedBag<Student>> courses)
        {
            string[] fields = record.Split('|');
            Student student = new Student(fields[0].Trim(), fields[1].Trim());

            if (courses.ContainsKey(fields[2].Trim()))
            {
                courses[fields[2].Trim()].Add(student);
            }
            else
            {
                courses.Add(fields[2].Trim(), new OrderedBag<Student>() { student });
            }
        }
    }
}
