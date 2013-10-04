namespace ExpentionMethods
{
    using System;
    using System.Text;

    public static class StringBuilderExtention
    {
        // Implement an extension method Substring(int index, int length) for the class StringBuilder 
        // that returns new StringBuilder and has the same functionality as Substring in the class String.
        public static StringBuilder Substring(this StringBuilder text, int index, int length)
        {
            if (index < 0 || index >= text.Length)
            {
                throw new IndexOutOfRangeException(string.Format("Index must be in range 0 - {0}", text.Length - 1));
            }

            if (length < 0 || length > text.Length)
            {
                throw new IndexOutOfRangeException(string.Format("Length must be in range 0 - {0}", text.Length));
            }
            
            if ((index + length) > text.Length)
            {
                throw new ArgumentOutOfRangeException("Substring is out of string borders", new ArgumentOutOfRangeException());
            }

            char[] chr = new char[length];
            text.CopyTo(index, chr, 0, length);
            return new StringBuilder(new string(chr));
        }
    }
}
