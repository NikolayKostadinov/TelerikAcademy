namespace BitArray64
{
    using System;

    // Define a class BitArray64 to hold 64 bit values inside an ulong value. 
    // Implement IEnumerable<int> and Equals(…), 
    // GetHashCode(), [], == and !=.

    public class BitArray64
    {
        private ulong bitContainer = 0;
        
        public BitArray64(ulong bitContainer)
        {
            this.bitContainer = bitContainer;
        }

        public BitArray64(string instring)
        {
            if (instring.Length < 64) 
            {
                throw new ArgumentException("Invalid input string!!!");
            }

            for (int i = 0; i < 64; i++)
            {
                this.BitContainer += (ulong)1 << int.Parse(instring[i].ToString());                  
            }
        }

        public ulong BitContainer
        {
            get
            {
                return this.bitContainer;
            }
            set
            {
                this.bitContainer = value;
            }
        }
    }
}
