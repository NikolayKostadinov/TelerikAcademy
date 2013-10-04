namespace _02.ConcatenateTwoTextFiles
{
    using System;
    using System.IO;
    using System.Text;

    public class ConcatenateTwoTextFiles
    {
        public static void Main()
        {
            try
            {
                string fileName1 = "file1.txt";
                string fileName2 = "file2.txt";
                string resultFileName = "result.txt";
                MergeFiles(fileName1, fileName2, resultFileName);
                Console.WriteLine(
                    "The files were merged successfully into file \"{0}\"!!!", 
                    resultFileName);
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
                Console.WriteLine(ex.Message + "Fatal Error!!!");
            }
        }

        private static void MergeFiles(string fileName1, string fileName2, string resultFileName)
        {
            StreamReader reader1 = 
                new StreamReader(fileName1, Encoding.GetEncoding("windows-1251"));
            using (reader1)
            {
                StreamWriter writer = 
                    new StreamWriter(resultFileName, false, Encoding.GetEncoding("windows-1251"));
                using (writer)
                {
                    string line = reader1.ReadLine();
                    
                    while (line != null)
                    {
                        writer.WriteLine(line);
                        line = reader1.ReadLine();
                    }  
                }
            }
            
            StreamReader reader2 =
                new StreamReader(fileName2, Encoding.GetEncoding("windows-1251"));
            using (reader2)
            {
                StreamWriter writer =
                    new StreamWriter(resultFileName, true, Encoding.GetEncoding("windows-1251"));
                using (writer)
                {
                    writer.WriteLine(".............................................................................................................");
                    string line = reader2.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine(line);
                        line = reader2.ReadLine();
                    }
                }
            }
        }
    }
}
