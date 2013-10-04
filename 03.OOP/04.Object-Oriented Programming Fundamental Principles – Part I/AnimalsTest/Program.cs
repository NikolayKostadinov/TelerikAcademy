namespace AnimalsTest
{
    using System;
    using System.Collections.Generic;
    using AnimalsCommon;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            IEnumerable<Animals> animals= new List<Animals>
            {
                        new Dogs("Sharo3", 10, Sex.Male),
                        new Frogs("Jaba1", 4, Sex.Female),
                        new Dogs("Sharo2", 9, Sex.Male),
                        new Kittens("kitty", 3),
                        new Frogs("Jaba2", 3, Sex.Female),
                        new Tomcats("Jerry", 3),
                        new Kittens("kitty", 2),
                        new Dogs("Sharo1", 8, Sex.Male),
                        new Tomcats("Jerry", 2),
                        new Kittens("kitty", 5),
                        new Frogs("Jaba3", 6, Sex.Female),
                        new Tomcats("Jerry", 1),
            };

            var result = animals.GroupBy(x => new {x = x.GetType().Name})
                .Select(g => new{ Average = g.Average(y => (double)y.Age), id = g.Key.x});

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
