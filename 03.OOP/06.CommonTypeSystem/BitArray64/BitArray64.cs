namespace BitArray64
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class BitArray64 : IEnumerable<int>
    {
        private ulong bitContainer = 0;
        
        public BitArray64(ulong bitContainer)
        {
            this.bitContainer = bitContainer;
        }

        public BitArray64(string instring)
        {
            if (instring.Length > 64) 
            {
                throw new ArgumentException("Invalid input string!!!");
            }

            for (int i = 0; i < instring.Length; i++)
            {
                this.BitContainer += ((ulong)1 * ulong.Parse(instring[i].ToString())) << (instring.Length - i - 1);                  
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

        public byte this[int i]
        {
            get
            {
                if (i < 0 || i > 63)
                {
                    throw new IndexOutOfRangeException("Index must be between 0 and 63");
                }

                return ((this.BitContainer & ((ulong)1 << (63 - i))) > 0) ? ((byte)1) : ((byte)0);
            }

            set
            {
                if (i < 0 || i > 63)
                {
                    throw new IndexOutOfRangeException("Index must be between 0 and 63");
                }

                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Value must be 1 or 0!!!");
                }

                if (value > 0)
                {
                    this.bitContainer = this.BitContainer | ((ulong)1 << i);
                }
                else
                {
                    this.bitContainer = this.BitContainer & (~((ulong)1 << i));
                }
            }
        }

        public static bool operator ==(BitArray64 bc1, BitArray64 bc2)
        {
            return BitArray64.Equals(bc1, bc2);
        }

        public static bool operator !=(BitArray64 bc1, BitArray64 bc2)
        {
            return !BitArray64.Equals(bc1, bc2);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = (result * 23) + this.bitContainer.GetHashCode();
                return result;
            }
        }
        
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder(64);

            for (int i = 0; i < 64; i++)
            {
                str.Append(this[i]);                
            }

            return str.ToString();
        }
    }
}
