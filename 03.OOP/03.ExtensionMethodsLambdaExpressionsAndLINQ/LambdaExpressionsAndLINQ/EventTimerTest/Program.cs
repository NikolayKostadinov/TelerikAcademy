namespace EventTimerTest
{
    using System;
    using MyTimer;

    class Program
    {
        static void Main()
        {
            string str = string.Empty;
            EventTimer myTimer = new EventTimer(1, DoAction);

            Thread timerThread = new Thread(myTimer.RunTimer);

            timerThread.Start();

            for (int i = 0; i < 100000; i++)
            {
                str += string.Format("{0}Test \r\n", action);
            }

            myTimer.StopTimer();
            Console.WriteLine(str);
        }

        private static void DoAction()
        {
            Console.WriteLine("Action {0} was done.", action++);
        }
        
    }
}
