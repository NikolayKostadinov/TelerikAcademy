namespace EventTimerTester
{
    using System;
    using EventTimerCommon;
    using System.Threading;
    
    class Program
    {
        static void Main()
        {
            CustomeTimer timer = new CustomeTimer(1);
            TimerSubscriber sub1 = new TimerSubscriber("sub1", timer);
            Thread ttimer = new Thread(timer.Start);
            ttimer.Start();

            string str = string.Empty;

            for (int i = 0; i < 50000; i++)
            {
                str += i + " iteration \r\n";
            }

            ttimer.Abort();
            Console.WriteLine(str);

        }
    }
}
