namespace InvalidRangeException
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private T start;
        private T end;

#region Constructors

        public InvalidRangeException(T start, T end) : this(string.Empty, start, end, null) 
        { 
        }

        public InvalidRangeException(string message, T start, T end) 
            : this(message, start, end, null) 
        { 
        }

        public InvalidRangeException(string message, T start, T end, Exception innerException) 
            : base(message + string.Format("[{0}...{1}]", start.ToString(), end.ToString()), innerException)
        {
            this.start = start;
            this.end = end;
        }
#endregion

#region Properties
        public T Start
        {
            get 
            { 
                return this.start; 
            }

            set 
            {
                this.start = value; 
            }
        }

        public T End
        {
            get 
            { 
                return this.end; 
            }
            
            set 
            { 
                this.end = value; 
            }
        } 
#endregion
 }
}
