namespace ApplicationExceptionDemo
{
    using System;
    using InvalidRangeException;
    class Program
    {
        static void Main()
        {
            try
            {
                //throw new InvalidRangeException<int>("Invalid range", 10, 20);
                throw new InvalidRangeException<DateTime>("Invalid range", DateTime.Now, DateTime.Now + new TimeSpan(20,0,0,0));
            }
            
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
