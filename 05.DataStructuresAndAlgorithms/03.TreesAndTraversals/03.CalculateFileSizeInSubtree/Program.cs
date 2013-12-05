namespace CalculateFileSizeInSubtree
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tree is building, please wait for few seconds...");
            DirectoryTree dirTree = new DirectoryTree("D:\\");

            Console.WriteLine("Done.");

            Console.WriteLine("\nTree size: ");
            double sizeInMB = dirTree.CalculateSizeOfTree();
            Console.WriteLine("{0:F2} megabytes", sizeInMB);
            Console.WriteLine("{0:F2} or gigabytes", sizeInMB / 1024);

            //in windows 8 AppCompat exists, you can try any other folder in Windows directory
            Console.WriteLine("\nCalculate size of tree folder and subfolders: ");
            sizeInMB = dirTree.CalculateSizeOfFolder("Work");
            Console.WriteLine("{0:F2} megabytes", sizeInMB);
            Console.WriteLine("{0:F2} or gigabytes", sizeInMB / 1024);

        }
    }
}
