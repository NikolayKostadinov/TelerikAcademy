namespace MyTimer
{
    using System;

    class EventTimerSubscriber
    {
        private string id;
        public EventTimerSubscriber(string id, EventTimer pub)
        {
            this.id = id;
            // Subscribe to the event using C# 2.0 syntax
            pub.RaiseTimerEvent  += HandleTimerEvent;
        }

        // Define what actions to take when the event is raised. 
        void HandleTimerEvent(object sender, TimerEventArgs e)
        {
            Console.WriteLine(id + " received this message: {0}", e.Message);
        }
    }
}
