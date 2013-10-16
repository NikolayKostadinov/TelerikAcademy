namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PdfDocument : EncriptableDocument
    {
        public uint NumberOfPages
        {
            get
            {
                return this.GetProperty("Pages").ToUInteger();
            }

            set
            {
                this.LoadProperty("Pages", value.ToString());
            }
        }
    }
}

