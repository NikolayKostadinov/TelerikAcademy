namespace TestStudentCommon
{
    using System;
    using System.Collections.Generic;
    using StudentsCommon;

    public class Program
    {
        public static void Main()
        {
            IEnumerable<ISpeakable> peoples =
                new List<ISpeakable>
                { 
                    new Student("Dicho"), 
                    new Student("Lelia Svetka"), 
                    new Employer("Milko Kalaijiev"),
                    new Student("Ico"),
                    new Speaker("Bla Bla Bla Bla"),
                };

            foreach (ISpeakable humanbeen in peoples)
            {
                humanbeen.PrintSpeach();
            }
        }
    }
}
