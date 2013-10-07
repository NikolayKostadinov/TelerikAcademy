namespace BankAccounts
{
    using System;

    public abstract class Customer
    {
        private string id;
        private string address;
        private string phoneNumber;

        public Customer(string id, string address, string phone) 
        {
            this.Id = id;
            this.Address = address;
            this.PhoneNumber = phone;
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArithmeticException("The field Id cannot be empty");
                }

                this.id = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArithmeticException("The field Address cannot be empty");
                }

                this.address = value;
            }
        }

        public string PhoneNumber
        {
            get 
            { 
                return this.phoneNumber; 
            }
            
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArithmeticException("The field First Name cannot be empty");
                }

                this.phoneNumber = value; 
            }
        }       
    }
}
