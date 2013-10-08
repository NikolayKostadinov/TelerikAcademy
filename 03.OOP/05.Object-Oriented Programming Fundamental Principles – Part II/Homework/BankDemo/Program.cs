namespace BankDemo
{
    using System;
    using System.Collections.Generic;
    using BankAccounts;
    class Program
    {
        static void Main()
        {
            Customer client1 = 
                new IndividualCustomer(
                    "7711240547",
                    "Лазур 18бл.", 
                    "0886630111", 
                    "Николай", 
                    "Костадинов");
            
            Customer client2 =
                new IndividualCustomer(
                    "5165656515",
                    "Изгрев 193бл.",
                    "0886123456",
                    "Христо",
                    "Григоров");

            Customer client3 =
                new CompanyCustomer(
                    "1234567890",
                    "пп Нефтохим",
                    "+3598863710",
                    "ИТСИБ ООД",
                    "0123456789");

            Customer client4 =
                new CompanyCustomer(
                    "1234567890",
                    "пп Нефтохим",
                    "+3598863710",
                    "ЛТСБ ООД",
                    "0123456789");

            IList<ICalculatable> accounts = new List<ICalculatable>
            {
                new DepositAccount(
                    client1,
                    1200M,
                    0.05M
                    ),

                new DepositAccount(
                    client3,
                    1200M,
                    0.05M),

                new LoanAccount(
                    client2,
                    100000M,
                    0.01M),

                new LoanAccount(
                    client4, 
                    100000M, 
                    0.02M),

                new MortgageAccount(
                    client1,
                    100000M,
                    0.012M),

                new MortgageAccount(
                    client3,
                    100000M,
                    0.012M),
            };
            int ix = 0;

            foreach (Account account in accounts)
            {
                ix++;
                Console.WriteLine(
                    "{0,-28} {1,-32} -> {2,13:C2}", 
                    account.ToString(), 
                    account.Awner.ToString(), 
                    account.CalculateInterestForPerion(12 + ix));
            }
        }
    }
}
