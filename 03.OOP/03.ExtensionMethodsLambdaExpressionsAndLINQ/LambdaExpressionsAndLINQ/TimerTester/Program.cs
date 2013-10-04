namespace TimerTester
{
    using System;
    using System.Threading;

    class Program
    {
        static ulong action = 0;

        static void Main(string[] args)
        {
            string str = string.Empty;
            MyTimer.Timer MyTimer = new MyTimer.Timer(1, DoAction);
            
            Thread timerThread = new Thread(MyTimer.RunTimer);

            timerThread.Start();

            for (int i = 0; i < 100000; i++)
            {
                str += string.Format("{0}Test \r\n", action);   
            }

            MyTimer.StopTimer();

            Console.WriteLine(str);
        }

        private static void DoAction()
        {
            Console.WriteLine("Action {0} was done.", action++); 
        }
    }
}
