using System;
using System.Threading;
//* Implement the "Falling Rocks" game in the text console. 
//A small dwarf stays at the bottom of the screen and can move 
//left and right (by the arrows keys). 
//A number of rocks of different sizes and forms constantly fall
//down and you need to avoid a crash.
//Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, 
//distributed with appropriate density. The dwarf is (O). 
//Ensure a constant game speed by Thread.Sleep(150).
//Implement collision detection and scoring system.
public struct Stone
{
    public char stoneType;
    public ConsoleColor color;
}

class FallingRocks
{
    const string dwarf = "(0)";
    
    static int consoleHeight = Console.WindowHeight;
    static int consoleWidth = Console.WindowWidth;
    static int dwarfPositionX = (consoleWidth/2 - 1);
    static ConsoleKeyInfo KeyPressed;
    static Random stoneGenerator = new Random();
    static Stone[,] stonesOnScreen = new Stone[1,1] ;
    static bool exitFlag = true;
    static float levelTimeout = 150f;
    static ulong scores = 0L;
    static int lives = 3;
    static string stoneSymbols = "^@*&+-%$#!.;,";
    static int gameLevel = 1;
    static string[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
    static int numColors = colorNames.Length;

    static void Main()
    {
        FixConsoleScreen();
        InicializeScreen();

        while (exitFlag)
        {
            if (Console.KeyAvailable)
            {
                KeyPressed = Console.ReadKey();
                if (KeyPressed.Key == ConsoleKey.Escape)
                {
                    exitFlag = false;
                    DrawGoodbuyScreen();
                    break;
                }
                else if (KeyPressed.Key == ConsoleKey.LeftArrow)
                {
                    MoveDwardLeft();
                }
                else if (KeyPressed.Key == ConsoleKey.RightArrow)
                {
                    MoveDwarRight();
                }
            }

            PopulateFirstLine();
            CalculateScore(); 
            RedrawScreen();
            ClearKeyBuffer();
            Thread.Sleep((int)levelTimeout);
        } 
    }

    private static void CalculateScore()
    {
        // TODO: Game score calculation
        if ((stonesOnScreen[consoleHeight - 5, dwarfPositionX].stoneType == ' ')&&
            (stonesOnScreen[consoleHeight - 5, dwarfPositionX + 1].stoneType == ' ')&&
            ((stonesOnScreen[consoleHeight - 5, dwarfPositionX + 2].stoneType == ' ')||
            (stonesOnScreen[consoleHeight - 5, dwarfPositionX + 2].stoneType == '\0')))
        {
            scores ++;
            if (scores > (ulong)gameLevel*1000)
            {
                gameLevel++;
                levelTimeout -= gameLevel * 0.5f;  
            }
        }
        else
        {
            lives--;
            if (lives > 0)
            {
                DrawLooseLive();
            }
            else
            {
                DrawGoodbuyScreen();
                exitFlag = false;      
            }
        }
    }

    private static void DrawLooseLive()
    {
        string message = "You Loose a Live!!!";
        Console.SetCursorPosition(((consoleWidth - message.Length) / 2), ((consoleHeight / 2) + 2));
        Console.Write("************************");
        Console.SetCursorPosition(((consoleWidth - message.Length) / 2), ((consoleHeight / 2) + 3));
        Console.Write("*{0,21} *", message);
        Console.SetCursorPosition(((consoleWidth - message.Length) / 2), ((consoleHeight / 2) + 4));
        Console.Write("************************");
        Thread.Sleep(3000); 
    }

    private static void PopulateFirstLine()
    {
        // TODO: Populating First line with random symbols
        int count = 0;
        if (gameLevel > 10)
        {
            count = 6;
        }
        else
        {
            count = (gameLevel / 3) + 2;
        }
        int StonesCount = stoneGenerator.Next(count);
        ShiftRowsDown();
        for (int i = 0; i < stonesOnScreen.GetLength(1) - 1; i++)
        {
            stonesOnScreen[0, i].stoneType = ' ';
        }

        for (int i = 0; i < StonesCount ; i++)
        {
            int stoneSyze = stoneGenerator.Next(gameLevel+1);
            int stonePosition = stoneGenerator.Next((stonesOnScreen.GetLength(1) - 1) - stoneSyze);
            int stoneType = stoneGenerator.Next(stoneSymbols.Length-1);  
            for (int j = 0; j < stoneSyze; j++)
            {
                stonesOnScreen [0,stonePosition+j].stoneType = Convert.ToChar(stoneSymbols.Substring(stoneType,1)) ;
                // Get random ConsoleColor string
                string colorName = colorNames[stoneGenerator.Next(1,numColors)];
                // Get ConsoleColor from string name
                stonesOnScreen[0, stonePosition + j].color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);
            }
        }

    }

    private static void ShiftRowsDown()
    {
        for (int i = stonesOnScreen.GetLength(0)-1 ; i > 0; i--)
        {
            for (int j = 0; j < stonesOnScreen.GetLength(1)-1 ; j++)
            {
                stonesOnScreen[i, j] = stonesOnScreen[i - 1, j];                
            }
            
        }
    }

    private static void ClearKeyBuffer()
    {
        // Clearing Console Input buffer
        while (Console.KeyAvailable)
        {
            Console.ReadKey(false);
        }
    }

    private static void MoveDwarRight()
    {
        // Moving dward to the Right
        if (dwarfPositionX < consoleWidth-4)
        {
            dwarfPositionX = dwarfPositionX + 1;
        }
    }
  
    private static void MoveDwardLeft()
    {
        // Moving dward to the Left
        if (dwarfPositionX > 0)
        {
            dwarfPositionX = dwarfPositionX - 1;
        }
    }

    private static void DrawGoodbuyScreen()
    {
        // Goodbuy Screen

        string message = "    GAME OVER!!!   ";
        Console.SetCursorPosition(((consoleWidth - message.Length) / 2), ((consoleHeight / 2) + 2));
        Console.Write("************************");
        Console.SetCursorPosition(((consoleWidth - message.Length) / 2), ((consoleHeight / 2) + 3));
        Console.Write("*{0,21} *", message);
        Console.SetCursorPosition(((consoleWidth - message.Length) / 2), ((consoleHeight / 2) + 4));
        Console.Write("************************");
        Thread.Sleep(3000); 
    }

    private static void RedrawScreen()
    {
        // Redraw screen on every loop
            RedrawStones();
            RedrawDwarf();
            RedrawScore();
    }

    private static void RedrawDwarf()
    {
        // Clearing old dwarf
        Console.SetCursorPosition(0, consoleHeight - 1);
        Console.Write("".PadLeft((stonesOnScreen.GetLength(1)), ' ')); // clear dwarf
        // Redrawing dward
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(dwarfPositionX, consoleHeight - 1);
        Console.Write(dwarf);
    }

    private static void RedrawScore()
    {
            // Redraw score board
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.Write("   SCORE:");
            Console.SetCursorPosition(0, 1);
            Console.Write("============");
            Console.SetCursorPosition(0, 2);
            Console.Write("|{0,10}|", scores);
            Console.SetCursorPosition(0, 3);
            Console.Write("============");

            Console.SetCursorPosition(consoleWidth - 13, 0);
            Console.Write("   LEVEL:");
            Console.SetCursorPosition(consoleWidth - 13, 1);
            Console.Write("============");
            Console.SetCursorPosition(consoleWidth - 13, 2);
            Console.Write("|{0,10}|", gameLevel);
            Console.SetCursorPosition(consoleWidth - 13, 3);
            Console.Write("============");
    }

    private static void RedrawStones()
    {
            //Redrawing Stones for background
        ClearStones();
            
        for (int i = 0; i < stonesOnScreen.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < stonesOnScreen.GetLength(1) - 1; j++)
            {
                if (stonesOnScreen[i, j].stoneType != ' ')
                {
                    Console.ForegroundColor = stonesOnScreen[i, j].color;
                    Console.SetCursorPosition(j, i + 4);
                    Console.Write(stonesOnScreen[i, j].stoneType);
                }
            }
        }
    }

    private static void ClearStones()
    {
        Console.SetCursorPosition(0, 4); 
        for (int i = 0; i < stonesOnScreen.GetLength(0) - 1; i++)
        {
            Console.WriteLine("".PadLeft((stonesOnScreen.GetLength(1) - 1),' '));
        }
    }

    private static void InicializeScreen()
    {
        for (int i = 0; i < stonesOnScreen.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < stonesOnScreen.GetLength(1) - 1; j++)
            {
                stonesOnScreen[i, j].stoneType = ' '; 
            }
        }
    }

    private static void FixConsoleScreen()
    {
        Console.WindowHeight = 40;
        consoleHeight = Console.WindowHeight;
        stonesOnScreen = new Stone[consoleHeight - 4, consoleWidth - 1];
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }
}

