namespace EventTimerCommon
{
    using System;

    public class TimerSubscriber
    {
        private string id;
        public TimerSubscriber(string id, CustomeTimer pub)
        {
            this.id = id;
            // Subscribe to the event using C# 2.0 syntax
            pub.RaiseTimerEvent += HandleTimerEvent;
        }

        // Define what actions to take when the event is raised. 
        private void HandleTimerEvent(object sender, TimerEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
