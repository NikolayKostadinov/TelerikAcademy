using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccounts
{
    public class LoanAccount : Account
    {
        protected LoanAccount(Customer awner, decimal balance, decimal mountlyInterestRate) 
            : base (awner,balance, mountlyInterestRate)  
        {
        }

        public override decimal CalculateInterestForPerion(int months)
        {
            throw new NotImplementedException();
        }
    }
}
