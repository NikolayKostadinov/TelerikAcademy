namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class ExtentionMethods
    {
        public static int ToInteger(this object obj) 
        {
            int result = 0;
            int.TryParse(obj.ToString(), out result);
            return result;
        }

        public static uint ToUInteger(this object obj)
        {
            uint result = 0;
            uint.TryParse(obj.ToString(), out result);
            return result;
        }

        public static ulong ToULong(this object obj)
        {
            ulong result = 0;
            ulong.TryParse(obj.ToString(), out result);
            return result;
        }
    }
}

