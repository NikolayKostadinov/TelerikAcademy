namespace GenericListTester
{
    using System;
    using GenericList.Common;

    public class Program
    {
        public static void Main()
        {
            const int ListSize = 10;
            try
            {
                GenericList<string> arr = new GenericList<string>(ListSize);
                PrintArray<string>(arr);

                for (int i = 0; i < ListSize; i++)
                {
                    arr.Add(i.ToString());
                }

                PrintArray<string>(arr);
                arr[9] = "10";
                PrintArray<string>(arr);
                arr.Insert(9, "9");
                PrintArray<string>(arr);

                Console.WriteLine(arr);

                Console.WriteLine(GenerikListHelper.Max<string>(arr));
                Console.WriteLine(GenerikListHelper.Min<string>(arr));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintArray<T>(GenericList<T> arr)
            where T : IComparable 
        {
            for (int i = 0; i < arr.Lenght; i++)
            {
                Console.WriteLine("{0} -> {1}", i, arr[i].ToString());
            }
        }
    }
}
