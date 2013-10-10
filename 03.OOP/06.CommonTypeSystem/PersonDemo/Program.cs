namespace PersonDemo
{
    using System;
    using System.Collections.Generic;
    using PersonCommon;

    public class Program
    {
        public static void Main()
        {
            List<Person> persons = new List<Person>()
            {
                new Person("Nikolay Kostadinov", 35),
                new Person("Hristo Grigorov", 36),
                new Person("Svetla Stoyanova"),
                new Person("Detelin Yolov", 42),
            };

            foreach (Person person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
