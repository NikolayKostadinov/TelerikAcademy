using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ClickCounter
{
    public class Counter
    {

        private static int counter;

        public Counter() 
        {
            counter++;
        }

        public int Count
        {
            get { return counter; }
        }
        
    }
}
