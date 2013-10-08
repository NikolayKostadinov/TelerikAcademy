namespace BankAccounts
{
    using System;

    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer awner, decimal balance, decimal mountlyInterestRate) 
            : base(awner, balance, mountlyInterestRate)  
        {
        }

        public override decimal CalculateInterestForPerion(int months)
        {
            // Mortgage accounts have ½ interest for the first 12 months for companies
            // and no interest for the first 6 months for individuals.
            decimal rate = 0;
            if (this.Awner is CompanyCustomer)
            {
                int monthsHalfRate = months > 12 ? 12 : months;
                int monthsNormalRate = months > 12 ? months - 12 : 0;

                rate = this.Balance * 
                    ((monthsHalfRate * (this.MounthlyInterestRate / 2)) +
                    (monthsNormalRate * this.MounthlyInterestRate));
            }
            else if (this.Awner is IndividualCustomer)
            {
                int monthsWithRate = months > 6 ? months : 0;
                rate = this.Balance * monthsWithRate * this.MounthlyInterestRate;
            }
            else 
            {
                throw new ArgumentException("Unknowd Account Type");
            }

            return rate;
        }
    }
}
