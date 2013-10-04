using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.WhichDayIsToday
{
    public class WhichDayIsToday
    {
        static void Main()
        {
            Days today = new Days((byte)DateTime.Now.DayOfWeek);
            Console.WriteLine("Today is {0}.", today);
        }
    }
}
