namespace DocumentSystem
{
    using System;
    using System.Linq;

    public abstract class MultimediaDicument : BinaryDocument
    {
        public int Lenght
        {
            get
            {
                return this.GetProperty("Lenght").ToInteger();
            }

            set
            {
                this.LoadProperty("Lenght", value.ToString());
            }
        }
    }
}

