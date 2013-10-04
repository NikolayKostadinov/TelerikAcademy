namespace MyTimer
{
    using System;
    using System.Linq;
    using System.Threading;
    
    public delegate void TimerAction();
 
    public class Timer
    {
        private readonly TimerAction timerAction;
        private bool stopped = false;
        private readonly int timerInterval;
        
        public Timer(int timerInterval, TimerAction timerAction)
        {
            if (timerInterval < 0 || timerInterval > (int.MaxValue / 1000)) 
            {
                throw new ArgumentOutOfRangeException(
                    string.Format(
                    "The interwal must be between 0 and {0}!!!", 
                    int.MaxValue / 1000)); 
            }

            this.timerInterval = timerInterval;
            this.timerAction = timerAction;
        }

        public void StopTimer() 
        {
            this.stopped = true; 
        }

        public void RunTimer()
        {
            while (!this.stopped)
            {
                Thread.Sleep(this.timerInterval * 1000);
                this.timerAction();
            }
        }
    }
}
