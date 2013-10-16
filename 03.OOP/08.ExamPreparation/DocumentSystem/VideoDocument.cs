namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class VideoDocument : MultimediaDicument
    {
        public uint FrameRate
        {
            get
            {
                return this.GetProperty("FrameRate").ToUInteger();
            }

            set
            {
                this.LoadProperty("FrameRate", value.ToString());
            }
        }
    }
}

