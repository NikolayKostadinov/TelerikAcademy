// -----------------------------------------------------------------------
// <copyright file="Days.cs" company="Manhattan">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace _03.WhichDayIsToday
{
    using System;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Days
    {
        private readonly byte day;
        public byte Day
        {
            get
            {
                return this.day;
            }
        }
   
        public Days(byte value)
        {
            if ((value < 1) || (value > 7)) throw new InvalidOperationException(); 
            this.day = value;
        }

        public override string ToString()
        {
            switch (this.Day)
            {
                case 1:
                    return "Monday"; 
                case 2:
                    return "Tuesday";
                case 3:
                    return "Wednesday";
                case 4:
                    return "Thirsday";
                case 5:
                    return "Friday";
                case 6:
                    return "Saturday";
                default:
                    return "Sunday";
            }
        }
    }
}
