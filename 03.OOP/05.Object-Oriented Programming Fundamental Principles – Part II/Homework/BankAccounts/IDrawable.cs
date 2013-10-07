using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccounts
{
    public interface IDrawable
    {
        void DrawMoney(decimal drawedSum);
    }
}
