namespace First20ProductsInPriceRange
{
    using System;

    internal class Product : IComparable<Product>
    {
        private string name = string.Empty;
        private decimal price = 0;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Name of product cannot be empty!");
                }

                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price of the product cannot be negative!");
                }

                this.price = value;
            }
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            string text = string.Format("{0,20} -> {1,-10:F2}", this.Name, this.Price);
            return text;
        }
    }
}
