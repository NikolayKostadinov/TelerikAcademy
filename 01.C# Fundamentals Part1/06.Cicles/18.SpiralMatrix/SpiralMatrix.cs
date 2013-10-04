using System;

namespace _18.SpiralMatrix
{
    class SpiralMatrix
    {
        static int[,] matrix;
        static void Main()
        {
            while (true)
            {
                Console.Write("Enter the size of the matrix: ");
                int matrixLenght = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (matrixLenght < 0) break;
                matrix = new int[matrixLenght, matrixLenght];
                PopulateMatrix();
                ConsoleWriteMatrix();
            }
        }
  
        private static void PopulateMatrix()
        {
            // TODO: Make a spiral Matrix
            int i = 0;
            int j = 0; 
            int currentCount = 1;
            int len = matrix.GetLength(0);
            int k = 0;
            int m = len;

            while (currentCount <= len*len)
            {
                for (j = i; j < len - i; j++ )
                {
                    matrix[i, j] = currentCount++;
                }
                j--;
                for (++i; i < len - k; i++ )
                {
                    matrix[i, j] = currentCount++;
                }
                k++;
                i--;
                for (j = len - k-1; j >= len - m; j--)
                {
                    matrix[i, j] = currentCount++;
                }
                m--;
                j++;
                for (i = len - k-1; i > k-1; i--)
                {
                    matrix[i, j] = currentCount++;
                }
                i++;
            }
        }
  
        private static void ConsoleWriteMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0) ; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3} ", matrix[i, j]);   
                }
                Console.WriteLine();
            }
        }
    }
}
