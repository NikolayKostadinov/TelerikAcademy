namespace RefactoringFunctionPrintStatistics
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            double [] arr = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            PrintStatistics(arr, 10);
        }

        public static void PrintStatistics(double[] arr, int count)
        {
            double maximalValue = FindMaximalValueInArray(arr, count);
            PrintResulToConsole("Maximal value of array is: ", maximalValue);

            double minimalValue = FindMinimalValueInArray(arr, count);
            PrintResulToConsole("Minimal value of array is: ", minimalValue);

            double averageValue = CaclulateAverageValueOfArray(arr, count);
            PrintResulToConsole("Average value of array is: ",averageValue);
        }

        private static double CaclulateAverageValueOfArray(double[] arr, int count)
        {
            double averageValue = 0;
            for (int i = 0; i < count; i++)
            {
                averageValue += arr[i];
            }
            averageValue = averageValue / count;
            return averageValue;
        }

        private static double FindMinimalValueInArray(double[] arr, int count)
        {
            double minimalValue = 0;
            for (int i = 0; i < count; i++)
            {
                if (arr[i] < minimalValue)
                {
                    minimalValue = arr[i];
                }
            }
            return minimalValue;
        }

        private static double FindMaximalValueInArray(double[] arr, int count)
        {
            double maximalValue = 0;
            for (int i = 0; i < count; i++)
            {
                if (arr[i] > maximalValue)
                {
                    maximalValue = arr[i];
                }
            }
            return maximalValue;
        }

        private static void PrintResulToConsole(string message, double inputValue)
        {
            Console.WriteLine(message + inputValue);
        }
    }
}
