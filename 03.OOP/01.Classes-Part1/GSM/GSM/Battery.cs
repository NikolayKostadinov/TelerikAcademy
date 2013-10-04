namespace GSM
{
    using System;

    public class Battery
    {
        private ushort hoursIdle = 0;
        private ushort hoursTalk = 0;

        public Battery()
        {
        }

        public Battery(string model, ushort hoursIdle, ushort hoursTalk, BatteryType type)
            : this(model, hoursIdle, hoursTalk) 
        {
            this.Type = type;
        }

        public Battery(string model, ushort hoursIdle, ushort hoursTalk)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        public Battery(string model)
            : this(model, 0, 0)
        {
        }

        public string Model { get; private set; }

        public BatteryType Type { get; set; }

        public ushort HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            set
            {
                if (value > 100)
                {
                    throw new
                       ArgumentOutOfRangeException(
                       "The value of Hours in Idle was too big. It must be between 0h and 100h");
                }

                this.hoursTalk = value;
            }
        }

        public ushort HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            set
            {
                if (value > 250)
                {
                    throw new
                    ArgumentOutOfRangeException(
                    "The value of Hours in Idle was too big. It must be between 0h and 250h");
                }

                this.hoursIdle = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Battery model is: {0}\nBattery Idle time: {1}\nBattery talk time: {2}\nBattery Type: {3}",
                this.Model,
                this.hoursIdle,
                this.hoursTalk,
                this.Type);
        }
    }
}