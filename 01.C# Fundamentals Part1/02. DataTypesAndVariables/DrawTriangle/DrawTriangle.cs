using System;

class DrawTriangle
{
    static void Main()
    {
        char symbol = '©';
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        //Drawing triangle
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j <= i ; j++)
            {
                Console.Write("{0}", symbol);
            }
            Console.WriteLine("");
        }     
    }
}

