namespace MyTimer
{
    using System;

    public class TimerEventArgs : EventArgs
    {
        private ulong secundes;
        private string message;

        public TimerEventArgs(ulong secundes)
        {
            this.secundes = secundes;
            this.message = string.Empty;
        }
        
        public ulong Secundes
        {
            get { return secundes; }
            set { secundes = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
