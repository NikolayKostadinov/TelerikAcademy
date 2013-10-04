namespace EventTimerCommon
{
    using System;

    public class TimerEventArgs: EventArgs
    {
        private string message;

        public string Message 
        {
            get 
            {
                return this.message;
            }

            set 
            {
                this.message = value;
            }
        }
    }
}
