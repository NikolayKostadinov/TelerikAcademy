using System;

class MaxSequence
{
    static void Main(string[] args)
    {
        //string[,] matrix = {
        //                       {"s", "qq", "s"},
        //                       {"pp", "s", "s"},
        //                       {"s", "qq", "pp"}
        //                   };

        string[,] matrix = {
                               {"ha", "fifi", "ho", "hi"},
                               {"fo", "ha", "hi", "xx"},
                               {"xxx", "ho", "ha", "xx"}
                           };
        int maxRow = 0;
        int maxCol = 0;
        int maxLen = 1;
        string maxString = "";

        //Print original matrix on the Console
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,4} ",matrix[row, col]);
            }

            Console.WriteLine();
        }
        DateTime begin = DateTime.Now;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int currLen = 1;
                for (int type = 0; type < 4; type++)
                {
                    currLen = MatrixParse(type, row, col, matrix);
                    if (currLen > maxLen)
                    {
                        maxLen = currLen;
                        maxRow = row;
                        maxCol = col;
                    }
                }
                
            }
        }

        Console.WriteLine("The maximal sequence in matrix is made from string \"{0}\" and has got lenght {1}.",
            matrix[maxRow,maxCol], maxLen);
        DateTime end = DateTime.Now;
        Console.WriteLine(begin - end);
    }

    private static int MatrixParse(int type, int row, int col, string[,] matrix)
    {
        int len = 0;

        switch (type)
        {
            case 0:
                len = MatrixParseRow(row, col, matrix);
                break;
            case 1:
                len = MatrixParseCol(row, col, matrix);
                break;
            case 2:
                len = len = MatrixParseDiagonalR(row, col, matrix);
                break;
            default:
                len = len = MatrixParseDiagonalL(row, col, matrix);
                break;
        }
        return len;
    }

    private static int MatrixParseDiagonalL(int row, int col, string[,] matrix)
    {
        int len = 1;
        for (int i = row+1, j=col-1; ((i < matrix.GetLength(0))&&(j >= 0)); i++, j--)
        {
            if (matrix[row, col] == matrix[i, j])
            {
                len++;
            }
            else
            {
                break;
            }
        }
        return len;       
    }

    private static int MatrixParseDiagonalR(int row, int col, string[,] matrix)
    {
        int len = 1;
        for (int i = row + 1, j = col + 1; ((i < matrix.GetLength(0)) && (j < matrix.GetLength(1))); i++, j++)
        {
            if (matrix[row, col] == matrix[i, j])
            {
                len++;
            }
            else
            {
                break;
            }
        }

        return len;
    }

    private static int MatrixParseCol(int row, int col, string[,] matrix)
    {
        int len = 1;
        for (int i = row; i < matrix.GetLength(0) - 1; i++)
        {
            if (matrix[i, col] == matrix[i+1, col])
            {
                len++;
            }
            else
            {
                break;
            }
        }

        return len;
    }

    private static int MatrixParseRow(int row, int col, string[,] matrix)
    {
        int len = 1;
        for (int j = col; j < matrix.GetLength(1) - 1; j++)
        {
            if (matrix[row, j] == matrix[row, j + 1])
            {
                len++;
            }
            else
            {
                break;
            }
        }

        return len;
    }
}