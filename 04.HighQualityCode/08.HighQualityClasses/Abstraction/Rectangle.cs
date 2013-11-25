using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        private double width = 0;

        private double height = 0;

        public Rectangle(double height, double width)
            : base() 
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get
            {
                return height;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height of the rectangle must be a positive number!");
                }

                height = value;
            }
        }

        public double Width
        {
            get 
            { 
                return width; 
            }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width of the rectangle must be a positive number!");
                }

                width = value; 
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
