namespace GSM
{
    using System;

    public class Display
    {
        private readonly ushort displaySize = 0;
        private readonly uint numberOfColors = 0;

        public Display()
        {
        }

        public Display(ushort displaySize, uint numberOfColors)
        {
            this.displaySize = displaySize;
            this.numberOfColors = numberOfColors;
        }

        public uint NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
        }

        public ushort DisplaySize
        {
            get
            {
                return this.displaySize;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Display size is: {0}\"\nDisplay number of colors is {1}",
                this.displaySize,
                this.numberOfColors);
        }
    }
}