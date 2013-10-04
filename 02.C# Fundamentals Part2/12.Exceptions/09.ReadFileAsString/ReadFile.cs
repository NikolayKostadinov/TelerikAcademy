namespace _09.ReadFileAsString
{
    // TODO: Напишете метод, който приема като параметър име на текстов файл, 
    // прочита съдържанието му и го връща като string.
    using System;
    using System.IO;
    using System.Text;

    public class ReadFile
    {
        public static void Main(string[] args)
        {
            string fileName = Console.ReadLine();
            string textInFile = string.Empty;
            Console.WriteLine(textInFile);
            try
            {
                textInFile = ReadFileAsString(fileName);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message + "\nNo such directory!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message + "\nNo such directory!");
            }
            catch (DirectoryNotFoundException) 
            {
                Console.WriteLine("No such directory!");
            }
            catch (FileNotFoundException) 
            {
                Console.WriteLine("No such file!");
            }
            catch (IOException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
  
        private static string ReadFileAsString(string fileName)
        {
            StringBuilder resultString = new StringBuilder();
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (sr.Peek() >= 0)
                {
                    resultString.Append(sr.ReadLine()); 
                }
            }

            return resultString.ToString(); 
        }
    }
}