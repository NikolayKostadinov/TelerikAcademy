namespace BankAccounts
{
    using System;

    public class LoanAccount : Account
    {
        public LoanAccount(Customer awner, decimal balance, decimal mountlyInterestRate) 
            : base(awner, balance, mountlyInterestRate)  
        {
        }

        public override decimal CalculateInterestForPerion(int months)
        {
            if (this.Awner is CompanyCustomer)
            {
                months -= months < 3 ? months : 3;
            }
            else if (this.Awner is IndividualCustomer)
            {
                months -= 2;
            }
            else 
            {
                throw new ArgumentException("Unknowd Account Type");
            }

            return months * this.MounthlyInterestRate * this.Balance;
        }
    }
}
