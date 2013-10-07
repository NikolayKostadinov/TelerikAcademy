namespace BankAccounts
{
    using System;

    public abstract class Account : ICalculatable, IDepositable
    {
        private decimal balance;
        private Customer awner;
        private decimal mouthlyInterestRate;

        protected Account( Customer awner, decimal balance, decimal mountlyInterestRate)
        {
            this.Awner = awner;
            this.Balance = balance;
            this.MounthlyInterestRate = mountlyInterestRate;
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Balance must be positive ot 0.");
                }

                this.balance = value;
            }
        }

        public decimal MounthlyInterestRate
        {
            get
            {
                return this.mouthlyInterestRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest rate must be positive or 0.");
                }

                this.mouthlyInterestRate = value;
            }
        }

        public Customer Awner
        {
            get
            {
                return this.awner;
            }

            set
            {
                if (this.awner == null)
                {
                    throw new ArgumentNullException("Account awner cannot be null!!");
                }
            }
        }

        public abstract decimal CalculateInterestForPerion(int months);

        public void MakeDeposit(decimal depositeSum)
        {
            if (depositeSum <= 0) 
            {
                throw new ArgumentOutOfRangeException("Deposited sum must be positive.");
            }

            this.balance += depositeSum;

        }
    }
}