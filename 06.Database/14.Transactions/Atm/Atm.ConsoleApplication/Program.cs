namespace Atm.ConsoleApplication
{
    using Atm.Data.Models;
    using Atm.Model;
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            using(AtmContext context = new AtmContext())
            {
                var result = from cardAccounts in context.CardAccounts
                             select cardAccounts;

                foreach (var cardAccount in result)
                {
                    Console.WriteLine(cardAccount);
                }
            }
        }
    }
}
