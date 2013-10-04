namespace Test1
{
    using System;
    using System.Text;
    using ExpentionMethods;

    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("Testing StringBuilder extention.");
            StringBuilder res = sb.Substring(0, 2);
            Console.WriteLine(res.ToString());
        }
    }
}
