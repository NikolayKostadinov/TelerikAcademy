# define DEMO
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Labirint
{
    internal class MatrinxCoordinate
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public MatrinxCoordinate(int x, int y)
        {
            this.Row = x;
            this.Col = y;
        }
    }

    internal class Program
    {
        private enum Direction { U = -1, D = 1, L = -1, R = 1 };

        static void Main(string[] args)
        {
            string[,] labirint = {
                                 {"s","*"," "," "," "},
                                 {" ","*"," ","*"," "},
                                 {" "," "," "," "," "},                                 
                                 {"*"," ","*","*"," "},
                                 {"*"," "," "," ","e"}
                                 };
            int counter = 0;
#if DEMO
            PrintLabirint(labirint);
#endif
            FindAllPaths(labirint, new MatrinxCoordinate(0, 0), "R", new Stack<string>(), ref counter);
        }

        private static void FindAllPaths(string[,] labirint, MatrinxCoordinate position, string direction, Stack<string> path, ref int pathCounter)
        {
            if (position.Row < 0 || position.Col < 0 || position.Row >= labirint.GetLength(0) || position.Col >= labirint.GetLength(1))
            {
                return;
            }

            path.Push(direction);
           
            if (labirint[position.Row, position.Col] == "e")
            {
                pathCounter++;
#if DEMO
                Prit(path, labirint.GetLength(0), pathCounter);
#else
                Prit(path, -1, pathCounter);
#endif
                path.Pop();
                return;
            }

            if (labirint[position.Row, position.Col] == " " || labirint[position.Row, position.Col] == "s")
            {
                labirint[position.Row, position.Col] = "v";
#if DEMO
                PrintLabirint(labirint);
#endif
                FindAllPaths(labirint, new MatrinxCoordinate(position.Row, position.Col + (int)Direction.L), "L", path, ref pathCounter);//goto left
                FindAllPaths(labirint, new MatrinxCoordinate(position.Row, position.Col + (int)Direction.R), "R", path, ref pathCounter);//goto right
                FindAllPaths(labirint, new MatrinxCoordinate(position.Row + (int)Direction.U, position.Col), "U", path, ref pathCounter);//goto up
                FindAllPaths(labirint, new MatrinxCoordinate(position.Row + (int)Direction.D, position.Col), "D", path, ref pathCounter);//goto down
                labirint[position.Row, position.Col] = " ";
#if DEMO
                PrintLabirint(labirint);
#endif
            }
            
            path.Pop();
        }

        private static void Prit(Stack<string> path, int offset, int counterFound)
        {
            Console.SetCursorPosition(0, offset + counterFound);

            string[] foundPath = new string[path.Count];
            path.CopyTo(foundPath, 0);

            for (int i = foundPath.Length - 2; i >= 0; i--)
            {
                Console.Write(foundPath[i]);
            }
            Console.WriteLine();
        }

        private static void PrintLabirint(string[,] labirint)
        {
            Console.SetCursorPosition(0, 0);

            for (int row = 0; row < labirint.GetLength(0); row++)
            {
                for (int col = 0; col < labirint.GetLength(1); col++)
                {
                    Console.Write("|" + labirint[row, col]);
                }
                Console.WriteLine("|");
            }

            Thread.Sleep(500);
        }
    }
}
