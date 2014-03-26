namespace MyTimer
{
    using System;
    using System.Linq;
    using System.Threading;
    
    public delegate void TimerAction();
 
    public class Timer
    {
        private TimerAction timerAction;
        private bool stopped = false;
        private int timerInterval;
        
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
           
            //Thread.Sleep(timerInterval * 1000); 
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
