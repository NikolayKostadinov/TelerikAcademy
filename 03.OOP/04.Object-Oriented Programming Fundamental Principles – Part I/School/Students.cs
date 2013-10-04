namespace School
{
    using System;

    public class Students : People
    {
        private int unicClassNumber;
        private Class _class;

        public Students(string name, int unicClassNumber, Class _class, string comment = "")
            : base(name, comment)
        {
            this.unicClassNumber = unicClassNumber;
            this.Class = _class;
        }

        public Class Class
        {
            get
            {
                return this._class;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cannot be given empti class.");
                }

                this._class = value;
            }
        }

        public int UnicClassNumber
        {
            get
            {
                return this.unicClassNumber;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Class identifier can't be a negativ number.", 
                        new ArgumentOutOfRangeException());
                }

                this.unicClassNumber = value;
            }
        }
    }
}
