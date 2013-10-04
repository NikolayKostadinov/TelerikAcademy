namespace GenerixMatrixTester
{
    using System;
    using Attribute;
    using GenericMatrix.Common;

    public class Program
    {
        public static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = 
                System.Globalization.CultureInfo.InvariantCulture; 
            try
            {
                int[,] mat1 = new int[,] 
                { 
                    { 1, -2, -3 }, 
                    { 2, 0, 1 }, 
                    { 1, 1, 1 } 
                };

                Matrix<int> matrix1 = new Matrix<int>(mat1);

                int[,] mat2 = new int[3, 3];
                
                Matrix<int> matrix2 = new Matrix<int>(mat2);

                Console.WriteLine(matrix1 ? "True" : "False");
                Console.WriteLine();
                Console.WriteLine(matrix2 ? "True" : "False");
                Type type = matrix1.GetType();

                foreach (var attr in type.GetCustomAttributes(false))
                {
                    if (attr is VersionAttribute)
                    {
                        Console.WriteLine("This is version {0} of the {1} class.",
                            (attr as VersionAttribute).Version, type.FullName);
                    }
                }

                Console.WriteLine();
                
                foreach (var attr in type.GetMethod("ToString").GetCustomAttributes(false)) 
                {
                    if (attr is VersionAttribute)
                    {
                        Console.WriteLine("This is version {0} of the {1} method.",
                            (attr as VersionAttribute).Version, type.GetMethod("ToString").Name);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }           
        }
    }
}
