namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AudioDocument : MultimediaDicument
    {
        public uint SampleRate 
        { 
            get
            {
                return this.GetProperty("SampleRate").ToUInteger();
            }
 
            set
            {
                this.LoadProperty("SampleRate", value.ToString());
            }
        }
    }
}

