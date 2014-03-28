using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsincFileReading
{
    class Program
    {
        static byte[] buffer = new byte[1024];
        static void Main(string[] args)
        {
            const string FilePath = @"D:\Downloads\Sygic 13.2.2\Sygic Map Downloader (TomTom 2013.06)\sgcmapdownloader.txt";
            FileStream fileStream = new FileStream(FilePath,
            FileMode.Open, FileAccess.Read, FileShare.Read, 1024,
            FileOptions.Asynchronous);
            IAsyncResult result = fileStream.BeginRead(buffer, 0, buffer.Length, 
                new AsyncCallback(CompleteRead), fileStream);
            Console.ReadLine();
        }
        static void CompleteRead(IAsyncResult result)
        {
            Console.WriteLine("Read Completed");
            FileStream strm = (FileStream)result.AsyncState;

            // Finished, so we can call EndRead and it will return without blocking
            int numBytes = strm.EndRead(result);
            strm.Close();
            Console.WriteLine("Read {0} Bytes", numBytes);
            Console.WriteLine(BitConverter.ToString(buffer));
        }
    }
}
