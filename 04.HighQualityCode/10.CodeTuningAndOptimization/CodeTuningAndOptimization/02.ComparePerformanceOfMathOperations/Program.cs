//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Manhattan Inc.">
//     Manhattan Inc.
// </copyright>
//-----------------------------------------------------------------------

namespace ComparePerformanceOfMathOperations
{
    using System;
    using System.Collections;
    using System.Diagnostics;

    /// <summary>
    /// Write a program to compare the performance of add, subtract, increment, 
    /// multiply, divide for integer, long, float, double and decimal values.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Method
        /// </summary>
        public static void Main()
        {
            // addition
            TestFunctionSpeed(
                () =>
                {
                    int counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter += 1;
                    }
                },
                "Adding integer");

            TestFunctionSpeed(
                () =>
                {
                    long counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter += 1;
                    }
                },
                "Adding long");

            TestFunctionSpeed(
                () =>
                {
                    float counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter += 1;
                    }
                },
                "Adding float");

            TestFunctionSpeed(
                () =>
                {
                    double counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter += 1;
                    }
                },
                "Adding double");

            TestFunctionSpeed(
               () =>
               {
                   decimal counter = 1;
                   for (int i = 0; i < 1000000; i++)
                   {
                       counter += 1;
                   }
               },
               "Adding decimal");

            Console.WriteLine(new string('-', 50));

            // substraction
            TestFunctionSpeed(
                () =>
                {
                    int counter = 10000000;
                    int substractor = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter = counter - substractor;
                    }
                },
                "Substracting integer");

            TestFunctionSpeed(
                () =>
                {
                    long counter = 1;
                    long substractor = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter = counter - substractor;
                    }
                },
                "Substracting long");

            TestFunctionSpeed(
                () =>
                {
                    float counter = 1;
                    float substractor = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter = counter - substractor;
                    }
                },
                "Substracting float");

            TestFunctionSpeed(
                () =>
                {
                    double counter = 1;
                    double substractor = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter = counter - substractor;
                    }
                },
                "Substracting double");

            TestFunctionSpeed(
                () =>
                {
                    decimal counter = 1;
                    decimal substractor = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter = counter - substractor;
                    }
                },
                "Substracting decimal");

            Console.WriteLine(new string('-', 50));

            // incrementation
            TestFunctionSpeed(
               () =>
               {
                   int counter = 1;
                   for (int i = 0; i < 1000000; i++)
                   {
                       counter++;
                   }
               },
               "Incrementing integer");

            TestFunctionSpeed(
                () =>
                {
                    long counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter++;
                    }
                },
                "Incrementing long");

            TestFunctionSpeed(
                () =>
                {
                    float counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter++;
                    }
                },
                "Incrementing float");

            TestFunctionSpeed(
                () =>
                {
                    double counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter++;
                    }
                },
                "Incrementing double");

            TestFunctionSpeed(
                () =>
                {
                    decimal counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter++;
                    }
                },
                "Incrementing decimal");

            Console.WriteLine(new string('-', 50));

            // multiplication
            TestFunctionSpeed(
                () =>
                {
                    int counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter *= counter;
                    }
                },
                "Multiplying integer");

            TestFunctionSpeed(
                () =>
                {
                    long counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter *= counter;
                    }
                },
                "Multiplying long");

            TestFunctionSpeed(
                () =>
                {
                    float counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter *= counter;
                    }
                },
                "Multiplying float");

            TestFunctionSpeed(
                () =>
                {
                    double counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter *= counter;
                    }
                },
                "Multiplying double");

            TestFunctionSpeed(
               () =>
               {
                   decimal counter = 1;
                   for (int i = 0; i < 1000000; i++)
                   {
                       counter *= counter;
                   }
               },
               "Multiplying decimal");

            Console.WriteLine(new string('-', 50));

            // divisvion
            TestFunctionSpeed(
                () =>
                {
                    int counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter /= 1;
                    }
                },
                "Dividing integer");

            TestFunctionSpeed(
                () =>
                {
                    long counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter /= 1;
                    }
                },
                "Dividing long");

            TestFunctionSpeed(
                () =>
                {
                    float counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter /= 1;
                    }
                },
                "Dividing float");

            TestFunctionSpeed(
                () =>
                {
                    double counter = 1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        counter /= 1;
                    }
                },
                "Dividing double");

            TestFunctionSpeed(
               () =>
               {
                   decimal counter = 1;
                   for (int i = 0; i < 1000000; i++)
                   {
                       counter /= 1;
                   }
               },
               "Dividing decimal");

            Console.WriteLine(new string('-', 50));

            Console.ReadKey();
        }

        /// <summary>
        /// Measuring function
        /// </summary>
        /// <param name="functionDelegate">Delegate for running every test</param>
        /// <param name="operation">Text message to display</param>
        private static void TestFunctionSpeed(Action functionDelegate, string operation)
        {
            Stopwatch testTimer = new Stopwatch();
            testTimer.Start();
            functionDelegate();
            testTimer.Stop();
            Console.WriteLine("{0,-30} -> {1}", operation, testTimer.Elapsed);
        }
    }
}
