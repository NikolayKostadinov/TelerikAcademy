namespace Atm.Data
{
    using System;
    using System.Linq;
    using Atm.Data.Models;
    using Atm.Model;

    public class Utility
    {
        public static CardAccount GetAccountDetails(CardAccount CardAccount)
        {
            using (AtmContext context = new AtmContext())
            {
                CardAccount cheskAccount = (from acc in context.CardAccounts
                                            where acc.CardNumber == CardAccount.CardNumber
                                            select acc).Single();
                if (cheskAccount != null)
                {
                    return cheskAccount;
                }
                else
                {
                    throw new ArgumentException("Account not found!!!");
                }
            }
        }
    }
}
