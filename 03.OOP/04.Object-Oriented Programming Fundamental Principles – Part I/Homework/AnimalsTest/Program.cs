namespace AnimalsTest
{
    using System;
    using System.Collections.Generic;
    using AnimalsCommon;

    public class Program
    {
        public static void Main()
        {
            IEnumerable<ISound> animals = new List<Animals>
            {
                        new Dogs("Sharo", 10, Sex.Male),
                        new Frogs("Jaba", 2, Sex.Female),
                        new Kittens("Kitten", 3),
                        new Tomcats("Tomcat", 2),
            };

            foreach (ISound animal in animals)
            {
                animal.DisplaySound();
            }
        }
    }
}
