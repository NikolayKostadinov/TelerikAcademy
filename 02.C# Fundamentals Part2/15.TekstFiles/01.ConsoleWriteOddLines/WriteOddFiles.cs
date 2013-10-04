namespace _01.ConsoleWriteOddLines
{
    using System;
    using System.IO;
    using System.Text;

    class WriteOddFiles
    {
        static void Main()
        {
            string fileName = @"..\..\WriteOddFiles.cs";
            try
            {
                StreamReader reader =
                    new StreamReader(fileName, Encoding.GetEncoding("windows-1251"));
                using (reader) 
                {
                    string line = reader.ReadLine() ;
                    ulong ix = 1;
                    while (line != null)
                    {
                        if (ix % 2 != 0) 
                        {
                            Console.WriteLine(line);
                        }
                        line = reader.ReadLine();
                        ix++;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
