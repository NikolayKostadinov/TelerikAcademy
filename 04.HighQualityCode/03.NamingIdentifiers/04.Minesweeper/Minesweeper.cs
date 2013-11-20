namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Minesweeper
    {
        static void Main(string[] arguments)
        {
            const int MAXIMAL_NUMBER_OF_MOVES = 35;
            string command = string.Empty;
            char[,] gameField = CreateGameField();
            char[,] bombMap = MapBombs();
            int counter = 0;
            bool isBombExplode = false;
            List<Score> hightScore = new List<Score>(6);
            int row = 0;
            int column = 0;
            bool isStratOfTheGame = true;
            bool isSuccesfulFinishedTheGame = false;

            do
            {
                if (isStratOfTheGame)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    PrintFieldOnConsole(gameField);
                    isStratOfTheGame = false;
                }
                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column) &&
                        row <= gameField.GetLength(0) && column <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                switch (command)
                {
                    case "top":
                        ShowHightScores(hightScore);
                        break;
                    case "restart":
                        gameField = CreateGameField();
                        bombMap = MapBombs();
                        PrintFieldOnConsole(gameField);
                        isBombExplode = false;
                        isStratOfTheGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombMap[row, column] != '*')
                        {
                            if (bombMap[row, column] == '-')
                            {
                                EvaluatePredictionOfBombsNumberForCurrentField(gameField, bombMap, row, column);
                                counter++;
                            }

                            if (MAXIMAL_NUMBER_OF_MOVES == counter)
                            {
                                isSuccesfulFinishedTheGame = true;
                            }
                            else
                            {
                                PrintFieldOnConsole(gameField);
                            }
                        }
                        else
                        {
                            isBombExplode = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }
                if (isBombExplode)
                {
                    PrintFieldOnConsole(bombMap);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                        "Daj si niknejm: ", counter);
                    string niknejm = Console.ReadLine();
                    Score t = new Score(niknejm, counter);
                    if (hightScore.Count < 5)
                    {
                        hightScore.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < hightScore.Count; i++)
                        {
                            if (hightScore[i].Points < t.Points)
                            {
                                hightScore.Insert(i, t);
                                hightScore.RemoveAt(hightScore.Count - 1);
                                break;
                            }
                        }
                    }
                    hightScore.Sort((Score r1, Score r2) => r2.PlayerName.CompareTo(r1.PlayerName));
                    hightScore.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    ShowHightScores(hightScore);

                    gameField = CreateGameField();
                    bombMap = MapBombs();
                    counter = 0;
                    isBombExplode = false;
                    isStratOfTheGame = true;
                }
                if (isSuccesfulFinishedTheGame)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    PrintFieldOnConsole(bombMap);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string imeee = Console.ReadLine();
                    Score to4kii = new Score(imeee, counter);
                    hightScore.Add(to4kii);
                    ShowHightScores(hightScore);
                    gameField = CreateGameField();
                    bombMap = MapBombs();
                    counter = 0;
                    isSuccesfulFinishedTheGame = false;
                    isStratOfTheGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void ShowHightScores(List<Score> hightScores)
        {
            Console.WriteLine("\nTo4KI:");
            if (hightScores.Count > 0)
            {
                for (int i = 0; i < hightScores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, hightScores[i].PlayerName, hightScores[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void EvaluatePredictionOfBombsNumberForCurrentField(char[,] gameField,
            char[,] bombsMap, int row, int col)
        {
            char kolkoBombi = kolko(bombsMap, row, col);
            bombsMap[row, col] = kolkoBombi;
            gameField[row, col] = kolkoBombi;
        }

        private static void PrintFieldOnConsole(char[,] gameField)
        {
            int maxRow = gameField.GetLength(0);
            int maxCol = gameField.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < maxRow; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < maxCol; j++)
                {
                    Console.Write(string.Format("{0} ", gameField[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] MapBombs()
        {
            int maxRow = 5;
            int maxCol = 10;
            char[,] gameField = new char[maxRow, maxCol];

            for (int i = 0; i < maxRow; i++)
            {
                for (int j = 0; j < maxCol; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> r3 = new List<int>();
            while (r3.Count < 15)
            {
                Random random = new Random();
                int asfd = random.Next(50);
                if (!r3.Contains(asfd))
                {
                    r3.Add(asfd);
                }
            }

            foreach (int i2 in r3)
            {
                int kol = (i2 / maxCol);
                int red = (i2 % maxCol);
                if (red == 0 && i2 != 0)
                {
                    kol--;
                    red = maxCol;
                }
                else
                {
                    red++;
                }
                gameField[kol, red - 1] = '*';
            }

            return gameField;
        }

        private static void smetki(char[,] pole)
        {
            int kol = pole.GetLength(0);
            int red = pole.GetLength(1);

            for (int i = 0; i < kol; i++)
            {
                for (int j = 0; j < red; j++)
                {
                    if (pole[i, j] != '*')
                    {
                        char kolkoo = kolko(pole, i, j);
                        pole[i, j] = kolkoo;
                    }
                }
            }
        }

        private static char kolko(char[,] r, int rr, int rrr)
        {
            int brojkata = 0;
            int reds = r.GetLength(0);
            int kols = r.GetLength(1);

            if (rr - 1 >= 0)
            {
                if (r[rr - 1, rrr] == '*')
                {
                    brojkata++;
                }
            }
            if (rr + 1 < reds)
            {
                if (r[rr + 1, rrr] == '*')
                {
                    brojkata++;
                }
            }
            if (rrr - 1 >= 0)
            {
                if (r[rr, rrr - 1] == '*')
                {
                    brojkata++;
                }
            }
            if (rrr + 1 < kols)
            {
                if (r[rr, rrr + 1] == '*')
                {
                    brojkata++;
                }
            }
            if ((rr - 1 >= 0) && (rrr - 1 >= 0))
            {
                if (r[rr - 1, rrr - 1] == '*')
                {
                    brojkata++;
                }
            }
            if ((rr - 1 >= 0) && (rrr + 1 < kols))
            {
                if (r[rr - 1, rrr + 1] == '*')
                {
                    brojkata++;
                }
            }
            if ((rr + 1 < reds) && (rrr - 1 >= 0))
            {
                if (r[rr + 1, rrr - 1] == '*')
                {
                    brojkata++;
                }
            }
            if ((rr + 1 < reds) && (rrr + 1 < kols))
            {
                if (r[rr + 1, rrr + 1] == '*')
                {
                    brojkata++;
                }
            }
            return char.Parse(brojkata.ToString());
        }
    }
}
