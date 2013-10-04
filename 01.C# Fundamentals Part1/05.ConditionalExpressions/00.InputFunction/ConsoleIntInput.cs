using System;

namespace InputFunction
{
    public static class ConsoleInput
    {
        private static object inputNumber = 0;
        
        public static int GetIntFromConsole(string message)
        {
            try
            {
                Console.Write(message);
                inputNumber = int.Parse(Console.ReadLine());
                return (int)inputNumber;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public static float GetfloatFromConsole(string message)
        {
            try
            {
                Console.Write(message);
                inputNumber = float.Parse(Console.ReadLine());
                return (float)inputNumber;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static double GetDoubleFromConsole(string message)
        {
            try
            {
                Console.Write(message);
                inputNumber = double.Parse(Console.ReadLine());
                return (double)inputNumber;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
