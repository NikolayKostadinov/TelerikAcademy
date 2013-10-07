namespace BankAccounts
{
    using System;

    public class MortgageAccount : Account
    {
        protected MortgageAccount(Customer awner, decimal balance, decimal mountlyInterestRate) 
            : base (awner,balance, mountlyInterestRate)  
        {
            this.interestCalculator = new MortgageDepositCalculator();
        }
    }
}
