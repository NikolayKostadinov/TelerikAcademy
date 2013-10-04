namespace _11.ParseFile
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Globalization;

    class ParseFiles
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;   

            try
            {
                ParseFile(); 
            }
            catch (FileParseException ex)
            {
                Console.WriteLine(ex.Message,ex.InnerException);    
            }

        }

        private static void ParseFile()
        {
            string fileName = @"D:\temp\test.txt";
            using (StreamReader sr = new StreamReader(fileName))
            {
                int line = 1;
                string lineText = string.Empty;
                try
                {
                    while (sr.Peek() > 0)
                    {
                        lineText = sr.ReadLine();
                        double.Parse(lineText);
                        line++;
                    }
                }
                catch (ArgumentNullException ex)
                {
                    string message = string.Format(
                        "Invalid entry on line {0}. \"{1}\" is not a number.", 
                        line, 
                        lineText);
                    throw new FileParseException(message, ex);
                }
                catch (FormatException ex)
                {
                    string message = string.Format(
                           "Invalid entry on line {0}. \"{1}\" is not a number.",
                           line,
                           lineText);
                    throw new FileParseException(message, ex);
                }
                catch (OverflowException ex)
                {
                    string message = string.Format(
                           "Invalid entry on line {0}. \"{1}\" is not a number.",
                           line,
                           lineText);
                    throw new FileParseException(message, ex);
                }
            }
        }
    }
}
