namespace Minesweeper
{
    using System;

    class GameEngine
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
}
