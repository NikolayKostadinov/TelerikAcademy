namespace BankAccounts
{
    using System;

    public interface IDepositable
    {
        void MakeDeposit(decimal depositeSum);
    }
}
