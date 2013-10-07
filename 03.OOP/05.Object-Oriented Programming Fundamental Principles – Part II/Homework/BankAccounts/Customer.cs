using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccounts
{
    public abstract class Customer
    {
        private string id;
        private string address;
        private string phoneNumber;

        public string PhoneNumber
        {
            get 
            { 
                return phoneNumber; 
            }
            
            set 
            { 
                phoneNumber = value; 
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
