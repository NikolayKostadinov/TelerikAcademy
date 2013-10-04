namespace EventTimerCommon
{
    using System;
    using System.Threading;

    public class CustomeTimer
    {
        private readonly int timerInterval = 0;
        private bool stopped = true;

        // Declare the event using EventHandler<T> 
        public event EventHandler<TimerEventArgs> RaiseTimerEvent;

        public CustomeTimer(int timerInterval)
        {
            if (timerInterval > int.MaxValue / 1000 || timerInterval < 0)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format(
                    "The intereval must be between 0 and {0}", 
                    int.MaxValue / 1000));
            }

            this.timerInterval = timerInterval;
            this.stopped = false;
        }

        public void Start()
        {
            try
            {
                while (!this.stopped)
                {
                    Thread.Sleep(timerInterval * 1000);
                    OnRaiseCustomEvent(new TimerEventArgs());
                }
            }
            catch (ThreadAbortException ex)
            {
                this.Stop(); 
            }
        }

        protected virtual void OnRaiseCustomEvent(TimerEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of 
            // a race condition if the last subscriber unsubscribes 
            // immediately after the null check and before the event is raised.
            EventHandler<TimerEventArgs> handler = RaiseTimerEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                e.Message += DateTime.Now.ToString();

                // Use the () operator to raise the event.
                handler(this, e);
            }
        }

        public void Stop()
        {
            this.stopped = true;
        }
    }
}
