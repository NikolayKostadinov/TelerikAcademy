namespace CalculateFileSizeInSubtree
{
    using System;
    using System.Linq;
    using System.Text;

    public class CalculateFileSizeInSubtree
    {
        internal static void Main()
        {
            string rootFolderName = @"C:\Windows";
            string folderName = @"C:\Windows";

            RootFolder root = new RootFolder(rootFolderName);
            long folderSize = root.GetFolderSize(folderName);
            PrintMessage(folderName, folderSize);

            folderName = @"C:\Windows\Globalization";
            folderSize = root.GetFolderSize(folderName);
            PrintMessage(folderName, folderSize);
        }

        private static void PrintMessage(string folderName, long folderSize)
        {
            int TabForSizeInBytes = long.MaxValue.ToString().Length;
            int TabForSizeInMegaBytes = (long.MaxValue / 1000000).ToString().Length;
            int TabForSizeInGigaBytes = (long.MaxValue / 1000000000).ToString().Length;

            double folderSizeInMegaBytes = folderSize/(1024 * 1024);
            double folderSizeInGigaBytes = folderSizeInMegaBytes/1024;
 
            StringBuilder messageLine1 = new StringBuilder();
            messageLine1.Append("Folder Name".PadLeft(folderName.Length+5));
            messageLine1.Append("Size in Bytes".PadLeft(TabForSizeInBytes + 5));
            messageLine1.Append("Size in MBytes".PadLeft(TabForSizeInMegaBytes+5));
            messageLine1.Append("Size in GBytes".PadLeft(TabForSizeInGigaBytes+5));

            string separator = new string('-', messageLine1.Length);

            StringBuilder messageLine2 = new StringBuilder();
            messageLine2.Append(folderName.PadLeft(5));
            messageLine2.Append(folderSize.ToString().PadLeft(TabForSizeInBytes + 5));
            messageLine2.Append(folderSizeInMegaBytes.ToString("F1").PadLeft(TabForSizeInMegaBytes+5));
            messageLine2.Append(folderSizeInGigaBytes.ToString("F1").PadLeft(TabForSizeInGigaBytes+5));

            Console.WriteLine(messageLine1);
            Console.WriteLine(separator);
            Console.WriteLine(messageLine2);
            Console.WriteLine();
        }
    }
}
