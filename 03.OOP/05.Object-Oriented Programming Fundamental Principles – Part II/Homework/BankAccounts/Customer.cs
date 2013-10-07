namespace BankAccounts
{
    using System;

    public abstract class Customer
    {
        private string id;
        private string address;
        private string phoneNumber;

        public string PhoneNumber
        {
            get 
            { 
                return this.phoneNumber; 
            }
            
            set 
            { 
                this.phoneNumber = value; 
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
            }
        }

        public string Address
        {
            get
            {
                return this.Address;
            }

            set
            {
            }
        }   
    }
}
