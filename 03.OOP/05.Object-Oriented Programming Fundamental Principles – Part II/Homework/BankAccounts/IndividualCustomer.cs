namespace BankAccounts
{
    using System;

    public class IndividualCustomer : Customer
    {
        private string firstName;
        private string lastName;

        public IndividualCustomer(string id, string address, string phone, string firstName, string lastName) 
            : base(id, address, phone)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArithmeticException("The field Last Name cannot be empty");
                }

                this.lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArithmeticException("The field First Name cannot be empty"); 
                }

                this.firstName = value;
            }
        }
    }
}
