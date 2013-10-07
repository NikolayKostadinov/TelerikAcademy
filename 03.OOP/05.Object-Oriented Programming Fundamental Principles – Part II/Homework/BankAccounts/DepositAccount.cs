namespace BankAccounts
{
    using System;

    public class DepositAccount : Account, IDrawable
    {
        protected DepositAccount(Customer awner, decimal balance, decimal mountlyInterestRate) 
            : base(awner, balance, mountlyInterestRate)  
        {
        }
 
        public void DrawMoney(decimal drawedSum)
        {
            if (drawedSum <= 0) 
            {
                throw new ArgumentOutOfRangeException("Drawed sum must be positive!"); 
            }

            if (drawedSum > this.Balance)
            {
                throw new ArgumentException("Drawed sum cannot be more than sum in account!");
            }

            this.Balance -= drawedSum;
        }

        public override decimal CalculateInterestForPerion(int months)
        {
            // Deposit accounts have no interest if their balance is positive and less than 1000.
            if (this.Balance > 1000)
            {
                return months * this.MounthlyInterestRate * this.Balance;
            }
            else
            {
                return 0;
            }
        }
    }
}
