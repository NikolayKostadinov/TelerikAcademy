namespace GSM
{
    using System;

    public class Call
    {
        public Call(DateTime dateTime, string dialedPhoneNumber, uint duration)
        {
            this.DateTime = dateTime;
            this.DialedPhoneNumber = dialedPhoneNumber;
            this.Duration = duration;
        }

        public Call(string dialedPhoneNumber, uint duration)
            : this(DateTime.Now, dialedPhoneNumber, duration)
        {
        }

        public DateTime DateTime { get; private set; }

        public string DialedPhoneNumber { get; private set; }

        public uint Duration { get; set; }

        public override string ToString()
        {
            // DateTime, DialedPhone, Duration
            string result = string.Format(
                "{0,25}{1,25}{2,20}", 
                this.DateTime, 
                this.DialedPhoneNumber,
                this.Duration);
            return result;
        }
    }
}