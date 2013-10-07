namespace BankAccounts
{
    using System;

    public class CompanyCustomer : Customer
    {
        private string companyName;
        private string companyId;

        public CompanyCustomer(string id, string address, string phone, string companyName, string companyId)
            : base(id, address, phone) 
        {
            this.CompanyName = companyName;
            this.CompanyId = companyId;
        }

        public string CompanyId
        {
            get
            {
                return this.companyId;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArithmeticException("The field CompanyId cannot be empty");
                }

                this.companyId = value;
            }
        }

        public string CompanyName
        {
            get
            {
                return this.companyName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArithmeticException("The field CompanyName cannot be empty");
                }

                this.companyName = value;
            }
        }
    }
}
