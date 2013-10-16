namespace DocumentSystem
{
    using System;
    using System.Linq;

    public abstract class BinaryDocument : Document
    {
        public ulong Syze
        {
            get
            {
                return this.GetProperty("Syze").ToULong();
            }

            set
            {
                this.LoadProperty("Syze", value.ToString());
            }
        }
    }
}

