namespace BankAccounts
{
    using System;

    public class DepositAccount : Account, IDrawable
    {    
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
    }
}
