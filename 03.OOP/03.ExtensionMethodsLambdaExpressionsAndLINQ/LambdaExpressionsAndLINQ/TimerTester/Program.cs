namespace TimerTester
{
    using System;
    using System.Threading;

    class Program
    {
        static ulong action = 0;
        private static char[] simbol = @"\|/-".ToCharArray();

        static void Main(string[] args)
        {
            string str = string.Empty;
            int ix = 0;
            MyTimer.TimerAction timerAction = DoAction;
            timerAction += DoSomethingElse;

            MyTimer.Timer MyTimer = new MyTimer.Timer(1, timerAction);

            Thread timerThread = new Thread(MyTimer.RunTimer);

            timerThread.Start();

            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine(simbol[ix++]);
                Console.WriteLine("{0}Test", action);
                Thread.Sleep(100);
                Console.SetCursorPosition(0, 0);

                //str += string.Format("{0}Test \r\n", action);  
                ix = ix == 4 ? 0 : ix;
            }

            MyTimer.StopTimer();

            Console.WriteLine(str);
        }

        private static void DoAction()
        {
            Console.WriteLine("Action {0} was done.", action++);
        }

        public static void DoSomethingElse()
        {
            Console.WriteLine("I did something else.");
        }
    }
}
