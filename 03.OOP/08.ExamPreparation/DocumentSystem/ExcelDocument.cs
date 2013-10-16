namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ExcelDocument : OfficeDocument
    {
        public int NumberOfRows
        {
            get
            {
                return this.GetProperty("NumberOfRows").ToInteger();
            }

            set
            {
                this.LoadProperty("NumberOfRows", value.ToString());
            }
        }

        public int NumberOfCols
        {
            get
            {
                return this.GetProperty("NumberOfCols").ToInteger();
            }

            set
            {
                this.LoadProperty("NumberOfCols", value.ToString());
            }
        }
    }
}


