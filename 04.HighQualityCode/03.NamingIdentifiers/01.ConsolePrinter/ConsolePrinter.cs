namespace ConsolePrinter
{
    using System;

    public class ConsolePrinter
    {
        private const int MAXCOUNT = 6;

        public static void Main()
        {
            ConsoleBoolPrinter printer = new ConsoleBoolPrinter();
            printer.WriteBoolAsStringToConsole(true);
        }

        internal class ConsoleBoolPrinter
        {
            public void WriteBoolAsStringToConsole(bool inputValue)
            {
                string inputValueAsString = inputValue.ToString();
                Console.WriteLine(inputValueAsString);
            }
        }
    }
}
