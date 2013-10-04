namespace MyTimer
{
    using System;
    using System.Threading;

    public class EventTimer
    {
        private ulong secundeCounter = 0;
        private readonly TimerAction timerAction;
        private bool stopped = false;
        private readonly int timerInterval;

        // Declare the event using EventHandler<T> 
        public event EventHandler<TimerEventArgs> RaiseTimerEvent;

        public EventTimer(int timerInterval, TimerAction timerAction)
        {
            if (timerInterval < 0 || timerInterval > (int.MaxValue / 1000)) 
            {
                throw new ArgumentOutOfRangeException(
                    string.Format(
                    "The interwal must be between 0 and {0}!!!", 
                    int.MaxValue / 1000)); 
            }

            this.timerInterval = timerInterval;
        }

        // event invoker method
        public void RunTimer()
        {
            while (!this.stopped)
            {
                Thread.Sleep(this.timerInterval * 1000);
                OnTimerTimer(new TimerEventArgs(this.secundeCounter++));
            }
        }

        // Wrap event invocations inside a protected virtual method 
        // to allow derived classes to override the event invocation behavior 
        protected virtual void OnTimerTimer(TimerEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of 
            // a race condition if the last subscriber unsubscribes 
            // immediately after the null check and before the event is raised.
            EventHandler<TimerEventArgs> handler = RaiseTimerEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Format the string to send inside the TimerEventArgs parameter
                e.Message += String.Format(" at {0}", DateTime.Now.ToString());

                // Use the () operator to raise the event.
                handler(this, e);
            }
        }
    }
}
