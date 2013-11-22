/// <summary>
/// Test program for Class Size
/// </summary>
namespace RefactoringClass
{
    using System;
    using System.Linq;

    /// <summary>
    /// Main Class of program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Function
        /// </summary>
        public static void Main()
        {
            bool areInputParamsCorrect = true;

            Console.Write("Enter width of the figure: ");
            double inputWidth = 0;
            areInputParamsCorrect = double.TryParse(Console.ReadLine(), out inputWidth);
            Console.Write("Enter height of the figure: ");
            double inputHeight = 0;
            areInputParamsCorrect = areInputParamsCorrect && double.TryParse(Console.ReadLine(), out inputHeight);

            if (!areInputParamsCorrect)
            {
                Console.WriteLine("You have to enter correct values for Width and Height of figure!!!");
                return;
            }

            double inputAngleOfRotation = 0;
            areInputParamsCorrect = areInputParamsCorrect && double.TryParse(Console.ReadLine(), out inputAngleOfRotation);

            if (!areInputParamsCorrect)
            {
                Console.WriteLine("You have to enter correct value for Angle of rotation for the figure!!!");
                return;
            }

            Size sourceFigure = new Size(inputWidth, inputHeight);
            Size rotatedFigure = GetRotatedSize(sourceFigure, inputAngleOfRotation);

            PrintToConsole(sourceFigure, rotatedFigure);
        }

        /// <summary>
        /// Get size of rotated figure
        /// </summary>
        /// <param name="sourceFigure">Source Figure</param>
        /// <param name="angleOfTheFigureThatWillBeRotated">Angle of Rotation</param>
        /// <returns>Size of the rotated figure</returns>
        public static Size GetRotatedSize(Size sourceFigure, double angleOfTheFigureThatWillBeRotated)
        {
            double modulusOfSinAngleOfRotation = Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotated));
            double modulusOfCosAngleOfRotation = Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotated));

            double rotatedFigureWidth = (modulusOfCosAngleOfRotation * sourceFigure.Width) +
                (modulusOfSinAngleOfRotation * sourceFigure.Height);

            double rotatedFigureHeight = (modulusOfSinAngleOfRotation * sourceFigure.Width) +
                (modulusOfCosAngleOfRotation * sourceFigure.Height);

            Size rotatedFigureSize = new Size(rotatedFigureWidth, rotatedFigureHeight);

            return rotatedFigureSize;
        }

        /// <summary>
        /// Print results to Console
        /// </summary>
        /// <param name="sourceFigure">Source Figure</param>
        /// <param name="rotatedFigure">Rotated Figure</param>
        private static void PrintToConsole(Size sourceFigure, Size rotatedFigure)
        {
            Console.WriteLine(
                "The size of source figure is:\nWidht: {0}\nHeight: {1}",
                sourceFigure.Width,
                sourceFigure.Height);
            Console.WriteLine(
                "The size of rotated figure is:\nWidht: {0}\nHeight: {1}",
                rotatedFigure.Width,
                rotatedFigure.Height);
        }
    }
}
