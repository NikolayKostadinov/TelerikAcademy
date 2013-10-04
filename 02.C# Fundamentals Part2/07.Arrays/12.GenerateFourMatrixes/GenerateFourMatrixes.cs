using System;

namespace _12.GenerateFourMatrixes
{
    class GenerateFourMatrixes
    {
        static void Main()
        {
            int matrixLen = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixLen, matrixLen];

            PopulateMatrixA(matrix);
            ConsoleWriteMatrix(matrix);
            ClearArray(matrix);
            PopulateMatrixB(matrix);
            ConsoleWriteMatrix(matrix);
            ClearArray(matrix);
            PopulateMatrixC(matrix);
            ConsoleWriteMatrix(matrix);
            ClearArray(matrix);
            PopulateMatrixD(matrix);
            ConsoleWriteMatrix(matrix);
        }

        private static void PopulateMatrixA(int[,] matrix)
        {
             // TODO: 1 5  9 13
             //       2 6 10 14
             //       3 7 11 15
             //       4 8 12 16
            int counter = 1;
            
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = counter++;   
                }
            }
        }

        private static void PopulateMatrixB(int[,] matrix)
        {
            // TODO: 1 8  9 16
            //       2 7 10 15
            //       3 6 11 14
            //       4 5 12 13
            int counter = 1;

            for (int col = 0; col < matrix.GetLength(1); col += 2)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = counter++;
                }
                if ((col + 1) < matrix.GetLength(1))
                {
                    for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                    {
                        matrix[row, col + 1] = counter++;
                    }
                }
            }
        }

        private static void PopulateMatrixC(int[,] matrix)
        {
            // TODO: 7 11 14 16
            //       4  8 12 15
            //       2  5  9 13
            //       1  3  6 14
            int counter = 1;
            for (int row = matrix.GetLength(0)-1; row >= 0; row--)
            {
                for (int col = 0; col < matrix.GetLength(1)-row; col++)
                {
                    matrix[row+col, col] = counter++;
                }
               
            }

            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                int col = i;
                for (int row = 0; row < matrix.GetLength(1)-i; row++ ,col++ )
                {
                    matrix[row,col] = counter++;
                }
                
            }
        }

        private static void PopulateMatrixD(int[,] matrix)
        {
            // TODO: 1 12 11 10
            //       2 13 16  9
            //       3 14 15  8
            //       4  5  6  7
            int counter = 1;
            int x = 0;
            int y = 0;
            int row = 0;
            int col = 0;

            while (counter <= matrix.Length)
            {
                
                for ( row = y; row < matrix.GetLength(0) - y ; row++)
                {
                    matrix[row, col] = counter++;
                }

                x++;
                row--;

                for (col = x; col < matrix.GetLength(1) - x + 1; col++)
                {
                    matrix[row, col] = counter++;
                }

                y++;
                col--;

                for ( row = row - 1; row >= y-1; row--)
                {
                    matrix[row, col] = counter++;
                }

                row++;

                for (col = col - 1; col >= x; col--)
                {
                    matrix[row, col] = counter++;
                }

                col++; 
            }
        }

        private static void ConsoleWriteMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,2} ", matrix[row, col]);
                }                

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void ClearArray(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }
        }       
    }
}
