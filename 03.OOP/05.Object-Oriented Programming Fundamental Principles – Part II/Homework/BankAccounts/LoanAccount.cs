namespace BankAccounts
{
    using System;

    public class LoanAccount : Account
    {
        protected LoanAccount(Customer awner, decimal balance, decimal mountlyInterestRate) 
            : base(awner, balance, mountlyInterestRate)  
        {
        }

        public override decimal CalculateInterestForPerion(int months)
        {
            if (this.Awner is CompanyCustomer)
            {
                months -= months < 3 ? months : 3;
            }
            else 
            {
                months -= 2;
            }

            return months * this.MounthlyInterestRate * this.Balance;
        }
    }
}
