using System;

class CircleAriaAndPerimeter
{
    static void Main()
    {
        double radius = 0.0;
        double perimeter = 0.0;
        double aria = 0.0;

        Console.Write("Enter the radius of circle: ");
        radius = double.Parse(Console.ReadLine());
        perimeter = 2 * Math.PI * radius;
        aria = Math.PI * radius * radius;

        Console.WriteLine("The perimeter of the circle with radius {0} is: {1}", radius, perimeter);
        Console.WriteLine("The aria of the circle with radius {0} is: {1}", radius, aria);
    }
}
