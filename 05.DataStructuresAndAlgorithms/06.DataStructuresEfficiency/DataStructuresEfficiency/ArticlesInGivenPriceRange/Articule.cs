namespace ArticlesInGivenPriceRange
{
    using System;
    using System.Text;
    
    class Articule : IComparable<Articule>
    {
        private int? barcode;
        private string vendor; 
        private string title; 
        private decimal price;

        public Articule(string vendor, string title, decimal price)
            : this(null, vendor, title, price) 
        { 
        }

        public Articule(int? barcode, string vendor, string title, decimal price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public int? Barcode
        {
            get
            {
                return this.barcode;
            }

            private set
            {
                this.barcode = value;
            }
        }

        public string Vendor
        {
            get
            {
                return this.vendor;
            }

            private set
            {
                CheckValue(value, "Vendor");
                this.vendor = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                CheckValue(value, "Title");
                this.title = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!!!");   
                }

                this.price = value;
            }
        }

        private void CheckValue(string value, string fieldName)
        {
            if (string.IsNullOrEmpty(value.Trim()))
            {
                throw new ArgumentException(fieldName + " cannot be empty!!!");
            }
        }

        public int CompareTo(Articule other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder(500);
            text.Append(string.Format("{0,-20}", this.Barcode));
            text.Append(" ");
            text.Append(string.Format("{0,-20}",this.Vendor));
            text.Append(" ");
            text.Append(string.Format("{0,-20}",this.Title));
            text.Append(" ");
            text.Append(string.Format("{0,20:F2}",Price));
            return text.ToString();
        }
    }
}
