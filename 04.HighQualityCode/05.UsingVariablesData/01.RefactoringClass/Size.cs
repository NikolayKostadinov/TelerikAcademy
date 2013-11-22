namespace RefactoringClass
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class for sizes
    /// </summary>
    public class Size
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Size" /> class
        /// </summary>
        /// <param name="width">Width of the figure</param>
        /// <param name="height">Height of the figure</param>
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Gets or sets Width Of The Figure
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets Height Of The Figure
        /// </summary>
        public double Height { get; set; }
    }
}