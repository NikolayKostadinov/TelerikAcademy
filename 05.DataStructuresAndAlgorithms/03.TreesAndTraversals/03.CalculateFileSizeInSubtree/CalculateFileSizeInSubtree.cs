namespace CalculateFileSizeInSubtree
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class CalculateFileSizeInSubtree
    {
        internal static void Main()
        {
            string rootFolderName = @"C:\Windows";
            string folderName = @"C:\Windows";

            RootFolder root = new RootFolder(rootFolderName);
            long folderSize = root.GetFolderSize(rootFolderName);
            PrintMessage(folderName, folderSize);

            folderName = @"C:\Windows\System32";
            folderSize = root.GetFolderSize(folderName);
            PrintMessage(folderName, folderSize);
        }

        private static void PrintMessage(string folderName, long folderSize)
        {
            int tabForSizeInBytes = long.MaxValue.ToString().Length;

            double folderSizeInMegaBytes = folderSize / (1024 * 1024);
            double folderSizeInGigaBytes = folderSizeInMegaBytes / 1024;

            StringBuilder message = new StringBuilder();
            message.Append("   Folder Name: ");
            message.Append(folderName.PadLeft(tabForSizeInBytes + 5) + "\n");
            int len = message.Length;
            message.Append(" Size in Bytes: ");
            message.Append(folderSize.ToString().PadLeft(tabForSizeInBytes + 5) + "\n");
            message.Append("Size in MBytes: ");
            message.Append(folderSizeInMegaBytes.ToString("F1").PadLeft(tabForSizeInBytes + 5) + "\n");
            message.Append("Size in GBytes: ");
            message.Append(folderSizeInGigaBytes.ToString("F1").PadLeft(tabForSizeInBytes + 5) + "\n");
            Console.WriteLine(message);
            string separator = new string('-', len + 2);
            Console.WriteLine(separator);
            Console.WriteLine();
        }
    }
}
