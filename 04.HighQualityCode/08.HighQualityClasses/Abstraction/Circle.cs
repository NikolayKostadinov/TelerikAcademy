using System;

namespace Abstraction
{
    class Circle : Figure
    {
        private double radius = 0;

        public double Radius
        {
            get
            {
                return radius;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height of the rectangle must be a positive number!");
                }

                radius = value;
            }
        }

        public Circle(double radius)
            : base()
        {
            this.Radius = radius;
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
