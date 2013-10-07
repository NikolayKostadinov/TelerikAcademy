namespace ShapesDemo
{
    using System;
    using System.Collections.Generic;
    using Shapes;

    public class Program
    {
        public static void Main()
        {
            IList<Shape> shapes = new List<Shape>
            {
                new Triangle(1, 2),
                new Rectangle(2, 2),
                new Circle(2),
            };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape + " with surface: " + shape.CalculateSurface());
            }
        }
    }
}
