namespace _10.CopyBynaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        public static void Main()
        {
            string source = @"D:\Install\SetupDWGTrueView2013_64bit.exe";
            string destination = @"D:\temp\SetupDWGTrueView2013_64bit.exe";
            CopyFile(source, destination);
        }
  
        private static void CopyFile(string source, string destination)
        {
            using (FileStream inputFile = new FileStream(source, FileMode.Open, FileAccess.Read)) 
            {
                using (MemoryStream tempStorage = new MemoryStream())
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine();
                    }
                }

                byte[] bytes = new byte[65536]; // 64KB block                
            }
        }
    }
}
