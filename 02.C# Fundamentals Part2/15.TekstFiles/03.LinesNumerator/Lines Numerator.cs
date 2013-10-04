
namespace _03.LinesNumerator
{
    using System;
    using System.IO;
    using System.Text;

    class Program
    {
        static void Main()
        {
            string fileName = "input.txt";
            try
            {
                Console.WriteLine("Operation was started. Please wait!");
                NumerateFileLines(fileName);
                Console.WriteLine("Operation compleat successfully!");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Operation failed!");
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Operation failed!");
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Operation failed!");
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Operation failed!");
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Operation failed!");
                Console.WriteLine("Not enought memory to complete this operation!!!");
            }
        }

        private static void NumerateFileLines(string fileName)
        {
            AppendLineNumberToFile(fileName);
            CopyTomporaryFileToOriginal(fileName);
            FileInfo tempFile = new FileInfo("temp.txt");
            tempFile.Delete(); 
        }

        private static void CopyTomporaryFileToOriginal(string fileName)
        {
            StreamReader reader2 =
               new StreamReader("temp.txt", Encoding.GetEncoding("windows-1251"));
            using (reader2)
            {
                StreamWriter writer2 =
                    new StreamWriter(fileName, false, Encoding.GetEncoding("windows-1251"));
                using (writer2)
                {
                    string line = reader2.ReadLine();

                    while (line != null)
                    {
                        writer2.WriteLine(line);
                        line = reader2.ReadLine();
                    }
                }
            }   
        }

        private static void AppendLineNumberToFile(string fileName)
        {
            //First we will copy file into temporary file where we will make changes

            StreamReader reader1 =
                new StreamReader(fileName, Encoding.GetEncoding("windows-1251"));
            using (reader1)
            {
                StreamWriter writer1 =
                    new StreamWriter("temp.txt", false, Encoding.GetEncoding("windows-1251"));
                using (writer1)
                {
                    string line = reader1.ReadLine();
                    ulong ix = 1u;
                    while (line != null)
                    {
                        writer1.WriteLine(string.Format("Line {0,10}:", ix++) + line);
                        line = reader1.ReadLine();
                    }
                }
            }
        }
    }
}
