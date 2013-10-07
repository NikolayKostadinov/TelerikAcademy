namespace Shapes
{
    using System;

    public class Circle : Shape
    {
        public Circle(double diameter) : base(diameter, diameter) 
        { 
        }

        public override double CalculateSurface()
        {
            return Math.PI * Math.Pow(this.Height / 2, 2);   
        }

        public override string ToString()
        {
            return "Circle";
        }
    }
}
