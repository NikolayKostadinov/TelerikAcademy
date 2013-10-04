using System;

class Program
{
    static void Main()
    {
        string firstString = "Hello";
        string secondString = "World";
        object concatenatedString = firstString + " " + secondString;
        string thirtString = (string) concatenatedString;
        Console.WriteLine(thirtString);
    }
}

