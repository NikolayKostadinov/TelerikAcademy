namespace BankAccounts
{
    using System;

    public interface ICalculatable
    {
        decimal CalculateInterestForPerion(int months);
    }
}
