using System;

class MaxPlatform
{
    static void Main()
    {
        // Define platform size
        const int platformSize = 3;
        // Declare and initialize the matrix
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
               		
        // Find the maximal sum platform of size 2 x 2
        int bestSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;

        if ((n < platformSize) || (m < platformSize))
        {
            Console.WriteLine("There is no platform 3x3 available!!!");
        }
        else
        {
            int[,] matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    Console.Write("Enter matrix[{0},{1}]: ",row ,col);
                    matrix[row, col] = int.Parse(Console.ReadLine());
                }                
            }

            for (int row = 0; row <= matrix.GetLength(0) - platformSize; row++)
            {
                for (int col = 0; col <= matrix.GetLength(1) - platformSize; col++)
                {
                    int sum = 0;

                    for (int rowp = row; rowp < row + platformSize; rowp++)
                    {
                        for (int colp = col; colp < col + platformSize; colp++)
                        {
                            sum += matrix[rowp, colp];
                        }
                    }

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            // Print the result
            Console.WriteLine("The best platform is:");

            for (int rowp = bestRow; rowp < bestRow + platformSize; rowp++)
            {
                Console.Write("".PadLeft(5, ' '));
                for (int colp = bestCol; colp < bestCol + platformSize; colp++)
                {
                    Console.Write( (matrix[rowp, colp] + " "));
                }
                Console.WriteLine();
            }

            Console.WriteLine("The maximal sum is: {0}", bestSum);        
        }
    }
}
