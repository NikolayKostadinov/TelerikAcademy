namespace Shapes
{
    using System;

    public abstract class Shape
    {
        private double width;
        private double height;

        public Shape() : this(0, 0) 
        {
        }

        public Shape(double height, double width) 
        {
            this.Height = height;
            this.Width = width;
        }

        protected double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Height must be great or equal to 0!");
                }

                this.height = value;
            }
        }

        protected double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Width must be great or equal to 0!");
                }

                this.width = value;
            }
        }
    
        public abstract double CalculateSurface();
    }
}
