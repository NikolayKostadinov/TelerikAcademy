namespace FindFilesInWidowsDirectory
{
    using System;
    using System.IO;
    using System.Linq;

    public class Program
    {
        internal static void Main(string[] args)
        {
            DateTime begin = DateTime.Now;
            string directoryName = @"C:\Windows";
            GetDirectory(directoryName);
            DateTime end = DateTime.Now;
            Console.WriteLine(end - begin);
        }

        private static void GetDirectory(string directory)
        {
            bool isDirectoryExist = Directory.Exists(directory);

            if (!isDirectoryExist)
            {
                throw new ArgumentException("Invalid directoryName!!!");
            }

            try
            {
                var files = Directory.GetFileSystemEntries(directory, "*.exe");

                foreach (var fileName in files)
                {
                    string fileFullPath = fileName;
                    Console.WriteLine(fileFullPath);
                }

                var directories = Directory.GetDirectories(directory);

                foreach (var directoryName in directories)
                {
                    GetDirectory(directoryName);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
