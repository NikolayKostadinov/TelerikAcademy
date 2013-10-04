using System;

class MyAge
{
    static void Main()
    {
        int myCurrentAge = 0;
        try
        {
            Console.Write("Enter your current age: ");
            myCurrentAge = Convert.ToInt32( Console.ReadLine());
            if (myCurrentAge < 0)
            {
                throw new Exception();
            }
            Console.WriteLine("After ten years your age is going to be: {0}", myCurrentAge + 10);
        }
        catch (Exception)
        {
            Console.WriteLine("It's not a valid age!");
        }
        Console.WriteLine("Press eny key to continue...");
        Console.ReadKey();        
    }
}
